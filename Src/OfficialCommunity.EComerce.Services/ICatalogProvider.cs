using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Services
{
    public interface ICatalogProvider
    {
        Task<IStandardResponse<int>> GetProductsCount();
        Task<IStandardResponse<IList<Product>>> GetProducts(int page);
        Task<IStandardResponse<Product>> GetProduct(string id);
    }
}