using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressMapper;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Nuvango.Domains.Messages;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Nuvango.Services
{
    public partial class NuvangoService : IShippingService
    {
        private const string GetShippingRatesApi = "shipping_rates";
        private static readonly List<ShippingRate> GetShippingRatesError = null;
        public async Task<IStandardResponse<List<ShippingRate>>> GetShippingRates(
            string passport
            , Address address
            , string currency
            , IList<CartItem> items
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(GetShippingRatesApi)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                var request = new GetRatesRequest
                {
                    Currency = currency,
                    City = address.City,
                    Region = address.RegionCode,
                    Country = address.CountryCode,
                    Zip = address.Zip,
                    CartItems = Mapper.Map<IList<CartItem>, IList<Domains.Business.CartItem>>(items).ToList()
                };

                try
                {
                    var response = await _session.PostAsync<List<Domains.Business.ShippingRate>, GetRatesRequest>(GetShippingRatesApi, request);
                    return Mapper.Map<List<Domains.Business.ShippingRate>,List<ShippingRate>>(response).GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                    return GetShippingRatesError.GenerateStandardError("Operation Failed");
                }
            }
        }
    }
}