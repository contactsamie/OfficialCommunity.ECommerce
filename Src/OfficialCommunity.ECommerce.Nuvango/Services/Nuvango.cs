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

namespace OfficialCommunity.ECommerce.Nuvango.Services
{
    public class Nuvango : IShippingProvider
    {
        private readonly ISession _session;

        public Nuvango(ILogger logger, ISession session)
        {
            _session = session;
        }

        private string GetShippingRatesApi = "shipping_rates";
        public Task<IStandardResponse<IEnumerable<ShippingRate>>> GetShippingRates(
            Customer customer
            , Address address
            , string currency
            , IEnumerable<BasketLine> items
            )
        {
            var request = new GetRatesRequest
            {
                Currency = currency,
                ShippingAddress = Domains.Business.Address.From(customer, address),
                OrderItems = items.Select(Domains.Business.OrderItem.From).ToList()
            };

            try
            {

            }
            catch (Exception e)
            {
            }
        }
    }
}
