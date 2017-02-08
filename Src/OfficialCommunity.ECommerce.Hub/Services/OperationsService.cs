using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Hub.Domains.Commands;
using OfficialCommunity.ECommerce.Hub.Domains.Infrastructure;
using OfficialCommunity.ECommerce.Hub.Domains.Services;
using OfficialCommunity.ECommerce.Hub.Infrastructure;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Services
{
    public class OperationsService : IOperationsService
    {
        private readonly ILogger<OperationsService> _logger;
        private readonly OperationCommandQueue _operations;

        public OperationsService(ILogger<OperationsService> logger
                                    , OperationCommandQueue operations)
        {
            _logger = logger;
            _operations = operations;
        }

        public async Task<IStandardResponse<bool>> LogAsync(string passport
                                                                    , string message
                                                                    , Guid? internalCorrelationId = null
                                                                    , Guid? externalCorrelationId = null
                                                                    , object request = null
                                                                    , object response = null
                                                                    , object log = null
                                                                    , string createdBy = null
                                                                    , string level = Operation.None
            )
        {
            var entry = EntryContext.Capture
                                        .Passport(passport)
                                        .Name(nameof(LogAsync))
                                        .Data(nameof(message),message)
                                        .EntryContext
                                    ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var command = new OperationCommand(
                        message,
                        level,
                        request,
                        response,
                        log,
                        internalCorrelationId,
                        externalCorrelationId,
                        createdBy
                    );

                    await _operations.Ask(command, null);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, nameof(LogAsync));
                    return false.GenerateStandardError(nameof(LogAsync));
                }

                return true.GenerateStandardResponse();
            }
        }
    }
}
