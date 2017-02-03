using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage.Table;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Services.Services
{
    public class LockService : TableEntityServiceProvider<LockService.LockServiceConfiguration>, ILockService
    {
        public class LockServiceConfiguration : Configuration
        {
        }

        private readonly ILogger<LockService> _logger;

        public LockService(ILogger<LockService> logger
            , IOptions<LockServiceConfiguration> configuration)
            : base(configuration)
        {
            _logger = logger;
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

            using (_logger.BeginScope(entry))
            {
                var entity = new TableEntity
                {
                    PartitionKey = key,
                    RowKey = id
                };
                return await Create(entity);
            }
        }

        public async Task<StandardResponse<bool>> Read(string passport, string key, string id)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Read")
                    .Identity(nameof(key), key)
                    .Identity(nameof(id), id)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                var entity = await Read<TableEntity>(key, id);
                return entity.HasError ? false.GenerateStandardError(entity.StandardError)
                                            : true.GenerateStandardResponse();
            }
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

            using (_logger.BeginScope(entry))
            {
                var entity = await Delete<TableEntity>(key, id);
                return entity.HasError ? false.GenerateStandardError(entity.StandardError)
                                            : true.GenerateStandardResponse();
            }
        }
    }
}