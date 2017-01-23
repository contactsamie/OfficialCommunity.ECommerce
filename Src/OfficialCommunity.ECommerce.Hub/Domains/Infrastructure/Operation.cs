using System;
using System.ComponentModel.DataAnnotations;

namespace OfficialCommunity.ECommerce.Hub.Domains.Infrastructure
{

    public class Operation : BaseEntity
    {
        public const string Trace = "trace";
        public const string Debug = "debug";
        public const string Information = "information";
        public const string Warning = "warning";
        public const string Error = "error";
        public const string Critical = "critical";
        public const string None = "none";

        [MaxLength(16)]
        public string Level { get; set; }

        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public Guid? ExternalCorrelationId { get; set; }
        public Guid? InternalCorrelationId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Log { get; set; }

        [DataType(DataType.MultilineText)]
        public string Request { get; set; }

        [DataType(DataType.MultilineText)]
        public string Response { get; set; }
    }
}
