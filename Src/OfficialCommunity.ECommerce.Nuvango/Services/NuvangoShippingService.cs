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
    public partial class NuvangoService : IFufillmentShippingService
    {
        private const string GetShippingRatesApi = "shipping_rates";
        private static readonly List<ShippingRate> GetShippingRatesError = null;
        public async Task<IStandardResponse<List<ShippingRate>>> GetShippingRatesQuote(
            string passport
            , Address address
            , string currency
            , IList<CartItem> items
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(GetShippingRatesQuote))
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
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

                    var response = await _session.PostAsync<List<Domains.Business.ShippingRate>, GetRatesRequest>(GetShippingRatesApi, request);
                    return Mapper.Map<List<Domains.Business.ShippingRate>,List<ShippingRate>>(response).GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"{nameof(GetShippingRatesQuote)} Failed");
                    return GetShippingRatesError.GenerateStandardError($"{nameof(GetShippingRatesQuote)} Failed");
                }
            }
        }
    }
}