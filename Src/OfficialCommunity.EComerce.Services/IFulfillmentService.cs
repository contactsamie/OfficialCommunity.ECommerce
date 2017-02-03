using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IFulfillmentServiceFactory : IService
    {
        Task<IFulfillmentService> GetService(Dictionary<string, string> configuration);
    }

    public interface IFulfillmentService : IService
    {
        IFufillmentCatalogService Catalog { get; }
        IFufillmentOrdersService Orders { get; }
        IFufillmentShippingService Shipping { get; }
    }
}