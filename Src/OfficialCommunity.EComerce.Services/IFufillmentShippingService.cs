using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IFufillmentShippingService : IService
    {
        Task<IStandardResponse<List<ShippingRate>>> GetShippingRatesQuote(
            string passport
            , Address address
            , string currency
            , IList<CartItem> items);
    }
}
