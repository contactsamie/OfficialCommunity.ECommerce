using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IStoreProvider
    {
        string Provider { get; }

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