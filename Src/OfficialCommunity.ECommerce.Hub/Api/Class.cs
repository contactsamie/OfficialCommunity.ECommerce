using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.ECommerce.Services.Domains.Commands;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.Necropolis.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;

namespace OfficialCommunity.ECommerce.Hub.Api
{
    [Route("api/[controller]")]
    public class ShippingRateController : Controller
    {
        private readonly ILogger<ShippingRateController> _logger;
        private readonly IServiceProvider _services;
        private readonly IStoreEntityService _storeEntityService;
        private readonly ICatalogEntityService _catalogEntityService;

        public ShippingRateController(ILogger<ShippingRateController> logger
                                    , IServiceProvider services
                                    , IStoreEntityService storeEntityService
                                    , ICatalogEntityService catalogEntityService
            )
        {
            _logger = logger;
            _services = services;
            _storeEntityService = storeEntityService;
            _catalogEntityService = catalogEntityService;
        }

        [HttpPost("{token}")]
        public async Task<IActionResult> Quote(string token, [FromBody] GetShippingRateQuote.Request request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var entry = EntryContext.Capture
                    .Passport(request.Passport)
                    .Name(nameof(Quote))
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    // Validate token
                    // This is where the store id comes from
                    // Each external store will be given JWT token for lookup

                    var storeKey = Guid.Empty; // TODO

                    var store = await _storeEntityService.Read(request.Passport, storeKey);

                    if (store.HasError)
                    {
                        _logger.LogError($"Missing Store Key [{storeKey}]", store);
                        return BadRequest();
                    }

                    if (store.Response.Deleted)
                    {
                        _logger.LogError($"Store [{store.Response.Name}] is deleted");
                        return BadRequest();
                    }

                    if (!store.Response.Published)
                    {
                        _logger.LogError($"Store [{store.Response.Name}] is not published");
                        return BadRequest();
                    }

                    var providers = _services.GetServices<IFufillmentServiceFactory>()
                                                .ToList();

                    var rates = new List<FulfillmentProviderShippingRates>();

                    foreach (var catalog in store.Response.Catalogs)
                    {
                        var lookupCatalog = await _catalogEntityService.Read(request.Passport, catalog.Key);
                        if (lookupCatalog.HasError)
                        {
                            _logger.LogError($"Missing Catalog [{catalog.Key}:{catalog.Value}]");
                            return BadRequest();
                        }

                        var lookupProvider = providers.FirstOrDefault(p => p.Key == lookupCatalog.Response.ProviderKey);
                        if (lookupProvider == null)
                        {
                            _logger.LogError($"Missing Fulfillment Provider [{catalog.Value}]");
                            return BadRequest();
                        }

                        var service = await lookupProvider.GetInstance(request.Passport, lookupCatalog.Response.ProviderConfiguration);
                        if (service.HasError)
                        {
                            _logger.LogError($"Unable to get instance of Fulfillment Provider [{lookupCatalog.Response.ProviderKey}:{lookupCatalog.Response.ProviderKey}]");
                            return BadRequest();
                        }

                        var cartItems =
                            request.Items.Where(
                                    x => string.Equals(x.FulfillmentProvider, lookupProvider.Name, StringComparison.InvariantCultureIgnoreCase))
                                .ToList();

                        var serviceRates = await service.Response.Shipping.GetShippingRatesQuote(request.Passport
                                                                                            , request.Address
                                                                                            , request.Currency
                                                                                            , cartItems);

                        if (serviceRates.HasError)
                        {
                            _logger.LogError($"Unable to get rates from Fulfillment Provider [{lookupCatalog.Response.ProviderKey}:{lookupCatalog.Response.ProviderName}]", serviceRates);
                            return BadRequest();
                        }

                        rates.Add(new FulfillmentProviderShippingRates
                        {
                            Name = lookupProvider.Name,
                            Rates = serviceRates.Response
                        });
                    }

                    return Json(new GetShippingRateQuote.Response { FulfillmentProviderShippingRates = rates });
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Quote Failed");
                    return BadRequest();
                }
            }
        }
    }
}
