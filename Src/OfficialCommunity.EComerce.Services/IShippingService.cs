using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IShippingService : IService
    {
        Task<IStandardResponse<List<ShippingRate>>> GetShippingRates(
            string passport
            , Address address
            , string currency
            , IList<CartItem> items);
    }
}
