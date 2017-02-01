using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Isotope.Services
{
    public partial class IsotopeService : IShippingService
    {
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
                    .Name("GetShippingRates")
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                }
            }
            return GetShippingRatesError.GenerateStandardError("Operation Failed");
        }
    }
}