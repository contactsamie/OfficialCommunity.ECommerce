using System;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Hub.Domains.Services;
using OfficialCommunity.ECommerce.Hub.Extensions;
using OfficialCommunity.ECommerce.Hub.Infrastructure;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Jobs
{
    public class FulfillmentCreateJob : FulfillmentJob
    {
        private const string Job = nameof(FulfillmentCreateJob);
        private readonly ILogger<FulfillmentCreateJob> _logger;

        public FulfillmentCreateJob(ILogger<FulfillmentCreateJob> logger
            , IServiceProvider services
            , IOperationsService operations
            , ILockService @lock
            , ICatalogEntityService catalogEntityService
        ) : base(logger, services, operations, @lock, catalogEntityService)
        {
            _logger = logger;
        }

        [LogFailure]
        [Queue(Constants.Jobs.Fulfillment.Create.Servers.Read.Name)]
        [DisableConcurrentExecution(timeoutInSeconds: 60 * 60)]
        public async Task Read()
        {
            const string operation = nameof(Read);
            var passport = Passport.Generate();
            var batchId = Guid.NewGuid();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(operation)
                    .Identity(nameof(batchId), batchId)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                _logger.LogInformation($"{Job}:{operation}:Started({batchId})", batchId);

                var ordersToBeProcessed = 0;

                BackgroundJob.Enqueue<FulfillmentCreateJob>(x => x.Start(passport, batchId));

                await Operations.LogInformationAsync(
                     passport
                    , $"{Job}:{operation}({batchId}):Complete({ordersToBeProcessed})"
                    , batchId
                );
            }
        }

        [LogFailure]
        [Queue(Constants.Jobs.Fulfillment.Create.Servers.Start.Name)]
        [DisableConcurrentExecution(timeoutInSeconds: 60 * 60)]
        public async Task Start(string passport, Guid batchId)
        {
            const string operation = nameof(Start);

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(operation)
                    .Identity(nameof(batchId), batchId)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                _logger.LogInformation($"{Job}:{operation}:Started({batchId})", batchId);

                var ordersToBeProcessed = 0;

                BackgroundJob.Enqueue<FulfillmentCreateJob>(x => x.Create(passport, batchId));

                await Operations.LogInformationAsync(
                    passport
                    , $"{Job}:{operation}({batchId}):Complete({ordersToBeProcessed})"
                    , batchId
                );
            }
        }

        [LogFailure]
        [Queue(Constants.Jobs.Fulfillment.Create.Servers.Create.Name)]
        [DisableConcurrentExecution(timeoutInSeconds: 60 * 60)]
        public async Task Create(string passport, Guid batchId)
        {
            const string operation = nameof(Create);

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(operation)
                    .Identity(nameof(batchId), batchId)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                _logger.LogInformation($"{Job}:{operation}:Started({batchId})", batchId);

                var ordersToBeProcessed = 0;

                BackgroundJob.Enqueue<FulfillmentCreateJob>(x => x.Update(passport, batchId));

                await Operations.LogInformationAsync(
                    passport
                    , $"{Job}:{operation}({batchId}):Complete({ordersToBeProcessed})"
                    , batchId
                );
            }
        }

        [LogFailure]
        [Queue(Constants.Jobs.Fulfillment.Create.Servers.Update.Name)]
        [DisableConcurrentExecution(timeoutInSeconds: 60 * 60)]
        public async Task Update(string passport, Guid batchId)
        {
            const string operation = nameof(Update);

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(operation)
                    .Identity(nameof(batchId), batchId)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                _logger.LogInformation($"{Job}:{operation}:Started({batchId})", batchId);

                var ordersToBeProcessed = 0;

                BackgroundJob.Enqueue<FulfillmentCreateJob>(x => x.Stop(passport, batchId));

                await Operations.LogInformationAsync(
                    passport
                    , $"{Job}:{operation}({batchId}):Complete({ordersToBeProcessed})"
                    , batchId
                );
            }
        }

        [LogFailure]
        [Queue(Constants.Jobs.Fulfillment.Create.Servers.Stop.Name)]
        [DisableConcurrentExecution(timeoutInSeconds: 60 * 60)]
        public async Task Stop(string passport, Guid batchId)
        {
            const string operation = nameof(Stop);

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(operation)
                    .Identity(nameof(batchId), batchId)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                _logger.LogInformation($"{Job}:{operation}:Started({batchId})", batchId);

                var ordersToBeProcessed = 0;

                await Operations.LogInformationAsync(
                    passport
                    , $"{Job}:{operation}({batchId}):Complete({ordersToBeProcessed})"
                    , batchId
                );
            }
        }
    }
}