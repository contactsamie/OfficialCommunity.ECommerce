using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using OfficialCommunity.ECommerce.Hub.Domains.Infrastructure;
using OfficialCommunity.ECommerce.Hub.Domains.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Services
{
    public class LockService : ILockService
    {
        public class Configuration
        {
            public string ConnectionString { get; set; }
            public string TableName { get; set; }
            public int MaxRetries { get; set; }
            public int MinBackoffDelayInMilliseconds { get; set; }
            public int MaxBackoffDelayInMilliseconds { get; set; }
            public int DeltaBackoffInMilliseconds { get; set; }
        }

        public class Session
        {
            public CloudStorageAccount StorageAccount { get; set; }
            public CloudTableClient TableClient { get; set; }
            public CloudTable Table { get; set; }
            public RetryPolicy RetryPolicy { get; set; }

            public Session(Configuration configuration)
            {
                StorageAccount = CloudStorageAccount.Parse(configuration.ConnectionString);
                TableClient = StorageAccount.CreateCloudTableClient();
                var table = TableClient.GetTableReference(configuration.TableName);
                table.CreateIfNotExists();
                var retryStrategy = new ExponentialBackoff(configuration.MaxRetries
                                        , TimeSpan.FromMilliseconds(configuration.MinBackoffDelayInMilliseconds)
                                        , TimeSpan.FromMilliseconds(configuration.MaxBackoffDelayInMilliseconds)
                                        , TimeSpan.FromMilliseconds(configuration.DeltaBackoffInMilliseconds));

                RetryPolicy = new RetryPolicy<StorageTransientErrorDetectionStrategy>(retryStrategy);
            }
        }

        private readonly ILogger<LockService> _logger;
        private readonly Session _session;

        public LockService(ILogger<LockService> logger
                            , IOptions<Configuration> configuration)
        {
            _logger = logger;
            _session = new Session(configuration.Value);
        }

        public async Task<StandardResponse<bool>> Acquire(string passport, string key, string id)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Acquire")
                    .Identity(nameof(key), key)
                    .Identity(nameof(id), id)
                    .EntryContext
                ;

            var entity = new GenericTableEntity<bool>(key, id, true);

            using (_logger.BeginScope(entry))
            {

                var operation = TableOperation.Insert(entity);
                try
                {
                    var tableResult = await _session.RetryPolicy.ExecuteAsync(async () => await _session.Table.ExecuteAsync(operation));

                    if (tableResult != null
                        && IsSuccessStatusCode(tableResult.HttpStatusCode)
                        && tableResult.Result != null)
                    {
                        return true.GenerateStandardResponse();
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Acquire Lock Failed");
                    return false.GenerateStandardResponse();
                }
            }

            return false.GenerateStandardResponse();
        }

        public async Task<StandardResponse<bool>> Release(string passport, string key, string id)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Release")
                    .Identity(nameof(key), key)
                    .Identity(nameof(id), id)
                    .EntryContext
                ;

            var entity = new GenericTableEntity<bool>(key, id, true);

            using (_logger.BeginScope(entry))
            {

                var operation = TableOperation.Delete(entity);
                try
                {
                    var tableResult = await _session.RetryPolicy.ExecuteAsync(async () => await _session.Table.ExecuteAsync(operation));

                    if (tableResult != null
                        && IsSuccessStatusCode(tableResult.HttpStatusCode)
                        && tableResult.Result != null)
                    {
                        return true.GenerateStandardResponse();
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Release Lock Failed");
                    return false.GenerateStandardResponse();
                }
            }

            return false.GenerateStandardResponse();
        }

        private static bool IsSuccessStatusCode(int statusCode)
        {
            return (statusCode >= 200) && (statusCode <= 299);
        }
    }
}
