using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.Necropolis.Infrastructure;
using ExpressMapper;
using Kendo.Mvc.Extensions;
using OfficialCommunity.ECommerce.Hub.Domains.Editable;
using OfficialCommunity.ECommerce.Hub.Domains.Viewable;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Services;
using OfficialCommunity.Necropolis.Extensions;

namespace OfficialCommunity.ECommerce.Hub.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private const int CACHE_DURATION_IN_SECONDS = 60 * 10;
        private const string FULFILLMENT_PROVIDERS_ALL_KEY = "urn:cache:fufillment.providers.all";

        private readonly ILogger<CatalogController> _logger;
        private readonly ICatalogEntityService _catalogEntityService;
        private readonly ICacheManager _cache;
        private readonly IServiceProvider _services;

        public CatalogController(ILogger<CatalogController> logger
            , IServiceProvider services
            , ICacheManager cache
            , ICatalogEntityService catalogEntityService
        )
        {
            _logger = logger;
            _cache = cache;
            _services = services;
            _catalogEntityService = catalogEntityService;
        }

        private static async Task<IList<ViewableForeignKey<string>>> GetAllFulfillmentProviders(IServiceProvider services)
        {
            return services.GetServices<IFulfillmentService>()
                            .Select(x => new ViewableForeignKey<string>
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
                    .Name("Index")
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    ViewBag.ProviderKeys = await _cache.AcquireAsync(FULFILLMENT_PROVIDERS_ALL_KEY
                                                                , CACHE_DURATION_IN_SECONDS
                                                                , _services
                                                                , services => GetAllFulfillmentProviders(services)
                                                                );

                    var catalog = await _catalogEntityService.Read(passport);

                    if (catalog.HasError)
                    {
                        _logger.LogError("Catalog Read failed");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    }

                    ViewBag.Catalogs = Mapper.Map<IEnumerable<CatalogTableEntity>, IList<EditableCatalogTableEntity>>(catalog.Response);

                    return View();

                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Index Failed");
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([DataSourceRequest] DataSourceRequest request, EditableCatalogTableEntity editable)
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Create")
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var fulfillmentServices = _services.GetServices<IFulfillmentService>();
                    var fulfillmentService = fulfillmentServices.FirstOrDefault(x => x.Key == new Guid(editable.ProviderKey));

                    if (fulfillmentService == null)
                    {
                        _logger.LogError($"Create failed: missing FulfillmentService {editable.ProviderKey}");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    }

                    var providerConfiguration = new Dictionary<string, string>();
                    foreach (var property in fulfillmentService.ConfigurationProperties())
                    {
                        providerConfiguration[property] = string.Empty;
                    }

                    var entity = new CatalogTableEntity
                    {
                        Name = editable.Name,
                        Description = editable.Description,
                        ProviderName = fulfillmentService.Name,
                        ProviderKey = fulfillmentService.Key.ToString("D"),
                        ProviderConfiguration = providerConfiguration
                    };

                    var operation = await _catalogEntityService.Create(passport, entity, User.Identity.Name);
                    if (operation.HasError)
                    {
                        _logger.LogError("Create failed");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    }

                    var response = Mapper.Map<CatalogTableEntity, EditableCatalogTableEntity>(operation.Response);
                    return Json(new[] { response }.ToDataSourceResult(request, ModelState));
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Create Failed");
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update([DataSourceRequest] DataSourceRequest request, EditableCatalogTableEntity editable)
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Update")
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var entity = Mapper.Map<EditableCatalogTableEntity, CatalogTableEntity>(editable);

                    var operation = await _catalogEntityService.Update(passport, entity, User.Identity.Name);
                    if (operation.HasError)
                    {
                        _logger.LogError("Update failed");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    }

                    var response = Mapper.Map<CatalogTableEntity, EditableCatalogTableEntity>(operation.Response);
                    return Json(new[] { response }.ToDataSourceResult(request, ModelState));
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Update Failed");
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete([DataSourceRequest] DataSourceRequest request, EditableCatalogTableEntity editable)
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Delete")
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var entity = Mapper.Map<EditableCatalogTableEntity, CatalogTableEntity>(editable);

                    entity.Deleted = true;

                    var operation = await _catalogEntityService.Update(passport, entity, User.Identity.Name);
                    if (operation.HasError)
                    {
                        _logger.LogError("Delete failed");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                    }

                    var response = Mapper.Map<CatalogTableEntity, EditableCatalogTableEntity>(operation.Response);
                    return Json(new[] { response }.ToDataSourceResult(request, ModelState));

                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Delete  Failed");
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
        }
    }
}