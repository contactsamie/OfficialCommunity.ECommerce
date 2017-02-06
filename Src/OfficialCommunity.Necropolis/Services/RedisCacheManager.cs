using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Domains.Services;
using OfficialCommunity.Necropolis.Extensions;

namespace OfficialCommunity.Necropolis.Services
{
    public class DistributedCacheManager : ICacheManager
    {
        private readonly ILogger<DistributedCacheManager> _logger;
        private readonly IDistributedCache _cache;

        public DistributedCacheManager(ILogger<DistributedCacheManager> logger
                                    , IDistributedCache cache
            )
        {
            _logger = logger;
            _cache = cache;
        }

        public IStandardResponse<T> Get<T>(string key)
            where T : class
        {
            try
            {
                return Deserialize<T>(_cache.Get(key)).GenerateStandardResponse();
            }
            catch (Exception e)
            {
                const string message = "Get Failed";
                _logger.LogError(e, message);
                return default(T).GenerateStandardError(message);
            }
        }

        public async Task<IStandardResponse<T>> GetAsync<T>(string key)
            where T : class
        {
            try
            {
                return Deserialize<T>(await _cache.GetAsync(key)).GenerateStandardResponse();
            }
            catch (Exception e)
            {
                const string message = "Get Async Failed";
                _logger.LogError(e, message);
                return default(T).GenerateStandardError(message);
            }
        }

        public IStandardResponse<T> Set<T>(string key, T data, int cacheTime)
            where T : class
        {
            try
            {
                if (data == null)
                    return default(T).GenerateStandardResponse();

                _cache.Set(key, Serialize(data), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheTime)
                });

                return data.GenerateStandardResponse();
            }
            catch (Exception e)
            {
                const string message = "Set Failed";
                _logger.LogError(e, message);
                return data.GenerateStandardError(message);
            }
        }

        public async Task<IStandardResponse<T>> SetAsync<T>(string key, T data, int cacheTime)
            where T : class
        {
            try
            {
                if (data == null)
                    return default(T).GenerateStandardResponse();

                await _cache.SetAsync(key, Serialize(data), new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheTime)
                });

                return data.GenerateStandardResponse();
            }
            catch (Exception e)
            {
                const string message = "Set Async Failed";
                _logger.LogError(e, message);
                return data.GenerateStandardError(message);
            }
        }

        public IStandardResponse<bool> Refresh(string key)
        {
            try
            {
                _cache.Refresh(key);
                return true.GenerateStandardResponse();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Refresh Failed");
                return false.GenerateStandardResponse();
            }

        }

        public async Task<IStandardResponse<bool>> RefreshAsync(string key)
        {
            try
            {
                await _cache.RefreshAsync(key);
                return true.GenerateStandardResponse();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Refresh Async Failed");
                return false.GenerateStandardResponse();
            }
        }

        public IStandardResponse<bool> Remove(string key)
        {
            try
            {
                _cache.Remove(key);
                return true.GenerateStandardResponse();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Remove Failed");
                return false.GenerateStandardResponse();
            }
           
        }

        public async Task<IStandardResponse<bool>> RemoveAsync(string key)
        {
            try
            {
                await _cache.RemoveAsync(key);
                return true.GenerateStandardResponse();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Remove Async Failed");
                return false.GenerateStandardResponse();
            }
        }

        private static byte[] Serialize(object o)
        {
            if (o == null)
            {
                return null;
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, o);
                var objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        private static T Deserialize<T>(byte[] stream)
        {
            if (stream == null)
            {
                return default(T);
            }

            var binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream(stream))
            {
                var result = (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }
    }
}
