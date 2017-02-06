using System.Threading.Tasks;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.Necropolis.Domains.Services
{
    public interface ICacheManager
    {
        IStandardResponse<T> Get<T>(string key) where T : class;
        Task<IStandardResponse<T>> GetAsync<T>(string key) where T : class;

        IStandardResponse<T> Set<T>(string key, T data, int cacheTime) where T : class;
        Task<IStandardResponse<T>> SetAsync<T>(string key, T data, int cacheTime) where T : class;

        IStandardResponse<bool> Refresh(string key);
        Task<IStandardResponse<bool>> RefreshAsync(string key);

        IStandardResponse<bool> Remove(string key);
        Task<IStandardResponse<bool>> RemoveAsync(string key);
    }
}
