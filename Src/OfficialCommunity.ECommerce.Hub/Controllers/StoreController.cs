﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ExpressMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Hub.Domains.Editable;
using OfficialCommunity.ECommerce.Hub.Domains.Viewable;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.Necropolis.Domains.Services;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private const int CACHE_DURATION_IN_SECONDS = 60 * 10;
        private const string FULFILLMENT_PROVIDERS_ALL_KEY = "urn:cache:store.providers.all";

        private readonly ILogger<StoreController> _logger;
        private readonly ICatalogEntityService _catalogEntityService;
        private readonly IStoreEntityService _storeEntityService;
        private readonly ICacheManager _cache;
        private readonly IList<IStoreServiceFactory> _storeServiceFactories;
        private readonly IStoreTokenService _storeTokenService;

        public StoreController(ILogger<StoreController> logger
            , ICacheManager cache
            , ICatalogEntityService catalogEntityService
            , IStoreEntityService storeEntityService
            , IList<IStoreServiceFactory> storeServiceFactories
            , IStoreTokenService storeTokenService
        )
        {
            _logger = logger;
            _cache = cache;
            _catalogEntityService = catalogEntityService;
            _storeEntityService = storeEntityService;
            _storeServiceFactories = storeServiceFactories;
            _storeTokenService = storeTokenService;
        }

        private static async Task<IList<ViewableForeignKey<string>>> GetAllStoreProviders(IList<IStoreServiceFactory> storeServiceFactories)
        {
            return storeServiceFactories.Select(x => new ViewableForeignKey<string>
                {
                    Key = x.Key.ToString("D"),
                    Name = x.Name
                }).ToList();
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(Index))
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    ViewBag.ProviderKeys = await _cache.AcquireAsync(FULFILLMENT_PROVIDERS_ALL_KEY
                        , CACHE_DURATION_IN_SECONDS
                        , _storeServiceFactories
                        , factories => GetAllStoreProviders(factories)
                    );

                    var stores = await _storeEntityService.ReadEntities(passport);

                    if (stores.HasError)
                    {
                        _logger.LogError($"{nameof(Index)}:{nameof(_storeEntityService.ReadEntities)}");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    }

                    var mappedStores = Mapper.Map<IEnumerable<StoreTableEntity>, IList<EditableStoreTableEntity>>(stores.Response);
                    foreach (var mapped in mappedStores)
                    {
                        var token = _storeTokenService.GenerateToken(mapped.Secret, mapped.Salt, mapped.Id);
                        if (token.HasError)
                        {
                            _logger.LogError($"{nameof(Index)}:{nameof(_storeTokenService.GenerateToken)}");
                            return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                        }
                        mapped.Token = token.Response;
                    }

                    ViewBag.Stores = mappedStores;

                    return View();

                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"{nameof(Index)}");
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, EditableStoreTableEntity editable)
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(Create))
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var factory = _storeServiceFactories.FirstOrDefault(x => x.Key == editable.ProviderKey);

                    if (factory == null)
                    {
                        _logger.LogError($"{nameof(Create)} missing StoreService {editable.ProviderKey}");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    }

                    var providerConfiguration = new Dictionary<string, string>();
                    foreach (var property in factory.ConfigurationProperties())
                    {
                        providerConfiguration[property] = string.Empty;
                    }

                    var secret = _storeTokenService.GenerateSecretAsBytes(64);
                    if (secret.HasError)
                    {
                        _logger.LogError($"{nameof(Create)}:{nameof(_storeTokenService.GenerateSecretAsBytes)}:Secret");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    }

                    var salt = _storeTokenService.GenerateSecretAsBytes(8);
                    if (salt.HasError)
                    {
                        _logger.LogError($"{nameof(Create)}:{nameof(_storeTokenService.GenerateSecretAsBytes)}:Salt");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    }

                    var entity = new StoreTableEntity
                    {
                        Name = editable.Name,
                        Description = editable.Description,
                        ProviderName = factory.Name,
                        ProviderKey = factory.Key,
                        ProviderConfiguration = providerConfiguration,
                        Secret = Convert.ToBase64String(secret.Response),
                        Salt = Convert.ToBase64String(salt.Response),
                    };

                    var createOperation = await _storeEntityService.CreateEntity(passport, entity, User.Identity.Name);
                    if (createOperation.HasError)
                    {
                        _logger.LogError($"{nameof(Create)}:{nameof(_storeEntityService.CreateEntity)}");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    }

                    //var token = _storeTokenService.GenerateToken(secret.Response, createOperation.Response.Id);
                    //if (token.HasError)
                    //{
                    //    _logger.LogError($"{nameof(Create)}:{nameof(_storeTokenService.GenerateToken)}");
                    //    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    //}

                    //createOperation.Response.Secret = secret.Response;
                    //createOperation.Response.Token = token.Response;

                    //var updateOperation = await _storeEntityService.UpdateEntity(passport, createOperation.Response, User.Identity.Name);
                    //if (updateOperation.HasError)
                    //{
                    //    _logger.LogError($"{nameof(Create)}:{nameof(_storeEntityService.UpdateEntity)}");
                    //}

                    //var response = Mapper.Map<StoreTableEntity, EditableStoreTableEntity>(updateOperation.Response);

                    var response = Mapper.Map<StoreTableEntity, EditableStoreTableEntity>(createOperation.Response);
                    return Json(new[] { response }.ToDataSourceResult(request, ModelState));
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"{nameof(Create)}");
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, EditableStoreTableEntity editable)
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(Update))
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var entity = Mapper.Map<EditableStoreTableEntity, StoreTableEntity>(editable);

                    var operation = await _storeEntityService.UpdateEntity(passport, entity, User.Identity.Name);
                    if (operation.HasError)
                    {
                        _logger.LogError($"{nameof(Update)}:{nameof(_storeEntityService.UpdateEntity)}");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    }

                    var response = Mapper.Map<StoreTableEntity, EditableStoreTableEntity>(operation.Response);
                    return Json(new[] { response }.ToDataSourceResult(request, ModelState));
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"{nameof(Update)}");
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, EditableStoreTableEntity editable)
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(Delete))
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var entity = Mapper.Map<EditableStoreTableEntity, StoreTableEntity>(editable);

                    entity.Deleted = true;

                    var operation = await _storeEntityService.UpdateEntity(passport, entity, User.Identity.Name);
                    if (operation.HasError)
                    {
                        _logger.LogError($"{nameof(Delete)}:{nameof(_storeEntityService.UpdateEntity)}");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    }

                    var response = Mapper.Map<StoreTableEntity, EditableStoreTableEntity>(operation.Response);
                    return Json(new[] { response }.ToDataSourceResult(request, ModelState));

                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"{nameof(Delete)}");
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
        }
    }
}