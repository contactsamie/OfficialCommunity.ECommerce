using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Services.Domains.Commands;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Domains.Services;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IFufillmentCatalogService : IService
    {
        Task<IStandardResponse<GetEntityCountResponse>> GetProductsCount(string passport);
        Task<IStandardResponse<IList<Product>>> GetProducts(string passport, int page);
        Task<IStandardResponse<Product>> GetProduct(string passport, string id);
    }
}