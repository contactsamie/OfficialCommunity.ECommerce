using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OfficialCommunity.ECommerce.Hub.Domains.Commands;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Infrastructure
{
    /*
    public class OperationCommandQueue :
         CommandQueue<IOperationCommand, IStandardResponse<bool>>
    {
        private readonly IRepositoryAsync<Operation> _operations;

        public OperationCommandQueue(IRepositoryAsync<Operation> operations, int workerCount = 1)
            : base(workerCount)
        {
            _operations = operations;
        }

        public async Task<IStandardResponse<bool>> Ask(IOperationCommand command
           , CancellationToken? cancelToken
           )
        {
            return await Ask(command, Apply, cancelToken);
        }

        private async Task<IStandardResponse<bool>> Apply(IOperationCommand command)
        {
            try
            {
                string requestJson = null;
                if (command.Request != null)
                    requestJson = JsonConvert.SerializeObject(command.Request, Formatting.Indented)
                                                .Replace("\r\n", $"{Environment.NewLine}")
                                                .Replace("\\\"", "\"")
                                                ;

                string responseJson = null;
                if (command.Response != null)
                    responseJson = JsonConvert.SerializeObject(command.Response, Formatting.Indented)
                                                .Replace("\r\n", $"{Environment.NewLine}")
                                                .Replace("\\\"", "\"")
                                                ;

                string logJson = null;
                if (command.Log != null)
                    logJson = JsonConvert.SerializeObject(command.Log, Formatting.Indented)
                                                .Replace("\r\n", $"{Environment.NewLine}")
                                                .Replace("\\\"", "\"")
                                                ;

                var log = new Operation
                {
                    Id = command.Id,
                    Level = command.Level,
                    CreatedUtc = command.CreatedUtc,
                    CreatedBy = command.CreatedBy,
                    MachineName = command.MachineName,
                    Message = command.Message,
                    InternalCorrelationId = command.InternalCorrelationId,
                    ExternalCorrelationId = command.ExternalCorrelationId,
                    Request = requestJson,
                    Response = responseJson,
                    Log = logJson
                };

                log.Timestamp();

                await _operations.AddAsync(log);
            }
            catch (Exception ex)
            {
                return ex.GenerateStandardError<bool>();
            }

            return true.GenerateStandardResponse();
        }
    }
    */
}
