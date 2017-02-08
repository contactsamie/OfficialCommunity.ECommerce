using System;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Hub.Domains.Services;
using OfficialCommunity.ECommerce.Services.Domains.Services;

namespace OfficialCommunity.ECommerce.Hub.Jobs
{
    public abstract class FulfillmentJob : Job
    {
        protected readonly ICatalogEntityService CatalogEntityService;

        protected FulfillmentJob(ILogger logger
            , IServiceProvider services
            , IOperationsService operations
            , ILockService @lock
            , ICatalogEntityService catalogEntityService
        ) : base(logger, services, operations, @lock)
        {
            CatalogEntityService = catalogEntityService;
        }
    }
}