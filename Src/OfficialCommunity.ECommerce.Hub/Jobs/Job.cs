using System;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Hub.Domains.Services;
using OfficialCommunity.ECommerce.Services.Domains.Services;

namespace OfficialCommunity.ECommerce.Hub.Jobs
{
    public abstract class Job
    {
        protected readonly ILogger BaseLogger;
        protected readonly IServiceProvider Services;
        protected readonly IOperationsService Operations;
        protected readonly ILockService Lock;

        protected Job(ILogger logger
            , IServiceProvider services
            , IOperationsService operations
            , ILockService @lock
        )
        {
            BaseLogger = logger;
            Services = services;
            Operations = operations;
            Lock = @lock;
        }
    }
}

