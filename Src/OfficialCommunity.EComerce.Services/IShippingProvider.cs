using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IShippingProvider
    {
        Task<IStandardResponse<IEnumerable<ShippingRate>>> GetShippingRates(
            Customer customer
            , Address address
            , string currency
            , IEnumerable<BasketLine> items);
    }
}
