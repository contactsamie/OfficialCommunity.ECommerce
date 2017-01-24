using System;
using System.Threading.Tasks;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

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

        Task<bool> PostAsync<TR>(string api, TR request)
            where TR : class
            ;
    }
}