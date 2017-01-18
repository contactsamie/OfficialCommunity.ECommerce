using System.Net.Http;
using System.Threading.Tasks;

namespace OfficialCommunity.ECommerce.Nuvango.Infrastructure
{
    public interface ISession
    {
        Task<T> GetAsync<T>(string api) 
            where T : class
            ;

        Task<T> PostAsync<T,TR>(string api, TR request) 
            where T : class
            where TR : class
            ;
    }
}