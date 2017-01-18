using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IShippingProvider
    {
        Task<IStandardResponse<IList<ShippingRate>>> GetShippingRates(
            Customer customer
            , Address address
            , string currency
            , IList<BasketLine> items);
    }
}
