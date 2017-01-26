using System;
using OfficialCommunity.Necropolis.Domains.Commands;

namespace OfficialCommunity.ECommerce.Hub.Domains.Commands
{
    public interface IOperationCommand : ICommand
    {
        string CreatedBy { get; }
        string Message { get; }
        string Level { get; }
        Guid? ExternalCorrelationId { get; }
        Guid? InternalCorrelationId { get; }
        object Request { get; }
        object Response { get; }
        object Log { get; }
    }

    public class OperationCommand : Command, IOperationCommand
    {
        private OperationCommand()
        {
        }

        public OperationCommand(string message
                                , string level
                                , object request = null
                                , object response = null
                                , object log = null
                                , Guid? internalCorrelationId = null
                                , Guid? externalCorrelationId = null
                                , string createdBy = null
            ) : base()
        {
            Message = message;
            Level = level;
            Request = request;
            Response = response;
            Log = log;
            ExternalCorrelationId = externalCorrelationId;
            InternalCorrelationId = internalCorrelationId;
            CreatedBy = createdBy;
        }

        public string CreatedBy { get; private set; }
        public string Message { get; private set; }
        public string Level { get; private set; }
        public Guid? ExternalCorrelationId { get; private set; }
        public Guid? InternalCorrelationId { get; private set; }
        public object Request { get; private set; }
        public object Response { get; private set; }
        public object Log { get; private set; }
    }
}
