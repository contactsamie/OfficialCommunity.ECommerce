using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OfficialCommunity.ECommerce.Hub.Domains.Infrastructure;
using OfficialCommunity.ECommerce.Services.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Services
{
    public class CatalogService : TableEntityService<CatalogService.CatalogServiceConfiguration>
    {
        private const string PrimaryKey = "catalog";

        public class CatalogServiceConfiguration : Configuration
        {
        }

        private readonly ILogger<CatalogService> _logger;

        public CatalogService(ILogger<CatalogService> logger
            , IOptions<CatalogServiceConfiguration> configuration)
            : base(configuration)
        {
            _logger = logger;
        }

        public async Task<StandardResponse<CatalogTableEntity>> Create(string passport, CatalogTableEntity entity, string user)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Create")
                    .Identity("PrimaryKey", PrimaryKey)
                    .Identity(nameof(entity), entity.Id)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                var now = DateTime.UtcNow;

                entity.CreatedUtc = now;
                entity.CreatedBy = user;
                entity.LastUpdatedUtc = now;
                entity.LastUpdatedBy = user;

                var response = await Create(PrimaryKey, entity.Id.ToString("D"), entity);

                return response.HasError ? entity.GenerateStandardError(response.StandardError) : entity.GenerateStandardResponse();
            }
        }

        public async Task<StandardResponse<CatalogTableEntity>> Read(string passport, Guid id)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Read")
                    .Identity("PrimaryKey", PrimaryKey)
                    .Identity(nameof(id), id)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                return await Read<CatalogTableEntity>(PrimaryKey, id.ToString("D"));
            }
        }

        public async Task<StandardResponse<CatalogTableEntity>> Update(string passport, CatalogTableEntity entity, string user)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Update")
                    .Identity("PrimaryKey", PrimaryKey)
                    .Identity(nameof(entity), entity.Id)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                var now = DateTime.UtcNow;

                entity.LastUpdatedUtc = now;
                entity.LastUpdatedBy = user;

                return await InsertOrReplace(PrimaryKey, entity.Id.ToString("D"), entity);
            }
        }

        public async Task<StandardResponse<CatalogTableEntity>> Delete(string passport, CatalogTableEntity entity, string user)
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Delete")
                    .Identity("PrimaryKey", PrimaryKey)
                    .Identity(nameof(entity), entity.Id)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                var now = DateTime.UtcNow;

                entity.LastUpdatedUtc = now;
                entity.LastUpdatedBy = user;

                return await InsertOrReplace(PrimaryKey, entity.Id.ToString("D"), entity);
            }
        }
    }
}