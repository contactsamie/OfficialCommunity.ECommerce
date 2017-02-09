using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage.Table;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Services.Services
{
    public abstract class TableEntityService<T,TC> : TableEntityServiceProvider<TC>, ITableEntityService<T> 
        where T : IBaseTableEntity, ITableEntity, new()
        where TC : TableEntityServiceProvider<TC>.Configuration, new()
    {
        private readonly string _partitionKey;

        private readonly ILogger<TableEntityService<T, TC>> _logger;

        protected TableEntityService(ILogger<TableEntityService<T, TC>> logger
            , IOptions<TC> configuration
            )
            : base(configuration)
        {
            _logger = logger;
            _partitionKey = typeof(T).Name;
        }

        public async Task<StandardResponse<T>> Create(string passport, T entity, string user)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(Create))
                    .Identity("PrimaryKey", _partitionKey)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                var now = DateTime.UtcNow;

                var row = Guid.NewGuid().ToString("D");

                entity.Id = Guid.NewGuid();
                entity.CreatedUtc = now;
                entity.CreatedBy = user;
                entity.LastUpdatedUtc = now;
                entity.LastUpdatedBy = user;

                entity.PartitionKey = _partitionKey;
                entity.RowKey = entity.Id.ToString("D");

                var response = await Create(entity);

                return response.HasError ? entity.GenerateStandardError(response.StandardError) 
                                            : entity.GenerateStandardResponse();
            }
        }

        public async Task<StandardResponse<IEnumerable<T>>> Read(string passport)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(Read))
                    .Identity("PrimaryKey", _partitionKey)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                return await Read<T>(_partitionKey);
            }
        }

        public async Task<StandardResponse<T>> Read(string passport, Guid id)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(Read))
                    .Identity("PrimaryKey", _partitionKey)
                    .Identity(nameof(id), id)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                return await Read<T>(_partitionKey, id.ToString("D"));
            }
        }

        public async Task<StandardResponse<T>> Update(string passport, T entity, string user)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(Update))
                    .Identity("PrimaryKey", entity.PartitionKey)
                    .Identity("RowKey", entity.RowKey)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                var now = DateTime.UtcNow;

                entity.LastUpdatedUtc = now;
                entity.LastUpdatedBy = user;

                return await InsertOrReplace(entity);
            }
        }

        public async Task<StandardResponse<T>> Delete(string passport, T entity, string user)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(Delete))
                    .Identity("PrimaryKey", _partitionKey)
                    .Identity("RowKey", entity.RowKey)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                var now = DateTime.UtcNow;

                entity.LastUpdatedUtc = now;
                entity.LastUpdatedBy = user;

                return await InsertOrReplace(entity);
            }
        }
    }
}