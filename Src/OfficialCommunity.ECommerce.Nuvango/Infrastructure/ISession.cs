using System;
using System.Threading.Tasks;

namespace OfficialCommunity.ECommerce.Nuvango.Infrastructure
{
    public interface ISession
    {
        Task<T> GetAsync<T>(string api, Func<string, T> deserializer = null) 
            where T : class
            ;

        Task<T> PostAsync<T,TR>(string api, TR request, Func<string, T> deserializer = null) 
            where T : class
            where TR : class
            ;
    }
}