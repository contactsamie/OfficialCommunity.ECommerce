using System.Net.Http;
using System.Threading.Tasks;

namespace OfficialCommunity.ECommerce.Nuvango.Infrastructure
{
    public interface ISession
    {
        Task<T> GetAsync<T>(HttpClient client, string api) 
            where T : class
            ;

        Task<T> PostAsync<T,TR>(HttpClient client, string api, TR request) 
            where T : class
            where TR : class
            ;
    }
}