using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.ECommerce.Services.Domains.Commands;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IOrdersService : IService
    {
        Task<IStandardResponse<GetEntityCountResponse>> GetOrdersCount(string passport);
        Task<IStandardResponse<IList<Order>>> GetOrders(string passport, int page);
        Task<IStandardResponse<Order>> GetOrder(string passport, string id);

        Task<IStandardResponse<bool>> PlaceOrder(
            string passport
            , Cart cart
        );
    }
}