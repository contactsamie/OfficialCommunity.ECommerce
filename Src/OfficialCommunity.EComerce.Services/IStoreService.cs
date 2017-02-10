using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Domains.Services;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IStoreService : IService
    {
        Task<IStandardResponse<IList<Order>>> GetNewOrders(
            string passport
            , string fufillmentProvider
            , string attributeOrderId
        );
        Task<IStandardResponse<IList<Order>>> GetUnshippedOrders(
            string passport
            , string fufillmentProvider
            , string attributeOrderId
        );
    }
}