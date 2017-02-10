using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.Necropolis.Domains.Services
{
    public interface IServiceFactory<T> : IServiceBase
        where T : class
    {
        IEnumerable<string> ConfigurationProperties();
        Task<IStandardResponse<T>> GetInstance(string passport
                    , Dictionary<string, string> properties
        );
    }
}
