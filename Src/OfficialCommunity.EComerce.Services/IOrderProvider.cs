using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IOrderProvider
    {
        Task<IStandardResponse<bool>> PlaceOrder(
            string passport
            , Customer customer
            , Address address
            , ShippingRate shippingRate
            , Order order
        );
    }
}