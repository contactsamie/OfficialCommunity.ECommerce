using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Nuvango.Domains.Messages;
using OfficialCommunity.ECommerce.Nuvango.Infrastructure;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Nuvango.Services
{
    public class Nuvango : IShippingProvider
    {
        private readonly ILogger _logger;
        private readonly ISession _session;

        public Nuvango(ILogger logger, ISession session)
        {
            _logger = logger;
            _session = session;
        }

        private const string GetShippingRatesApi = "shipping_rates";
        private static readonly IList<ShippingRate> GetShippingRatesError = null;
        public async Task<IStandardResponse<IList<ShippingRate>>> GetShippingRates(
            Customer customer
            , Address address
            , string currency
            , IList<BasketLine> items
            )
        {
            var entry = EntryContext.Capture
                    .Passport("")
                    .Name(GetShippingRatesApi)
                    .Identity(nameof(customer), customer)
                    .Data(nameof(address), address)
                    .Data(nameof(currency), currency)
                    .Data(nameof(items), items)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                var request = new GetRatesRequest
                {
                    Currency = currency,
                    ShippingAddress = Domains.Business.Address.From(customer, address),
                    OrderItems = items.Select(Domains.Business.OrderItem.From).ToList()
                };

                try
                {
                    var response = await _session.PostAsync<IList<ShippingRate>, GetRatesRequest>(GetShippingRatesApi, request);
                    return response.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    //_logger.LogError();.LogError((LoggingEvents.INSERT_ITEM, e, "Async error");
                    return GetShippingRatesError.GenerateStandardError("Operation Failed");
                }
            }
        }
    }
}
