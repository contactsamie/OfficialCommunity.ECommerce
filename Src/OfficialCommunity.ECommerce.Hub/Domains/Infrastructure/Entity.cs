using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OfficialCommunity.ECommerce.Hub.Domains.Infrastructure
{
    namespace NoSQL
    {
        public abstract class Entity
        {
            protected Entity(string type)
            {
                Type = type;
            }

            /// <summary>
            /// Object unique identifier
            /// </summary>
            [Key]
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("createdutc")]
            public DateTime? CreatedUtc { get; set; }

            [JsonProperty("createdby")]
            public string CreatedBy { get; set; }

            [JsonProperty("machinename")]
            public string MachineName { get; set; }

            /// <summary>
            /// Object type
            /// </summary>
            public string Type { get; private set; }
        }

        public class Operation : Entity
        {
            public const string Trace = "trace";
            public const string Debug = "debug";
            public const string Information = "information";
            public const string Warning = "warning";
            public const string Error = "error";
            public const string Critical = "critical";
            public const string None = "none";

            public Operation()
                : base("operation")
            {
            }

            [JsonProperty("level")]
            public string Level { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("externalcorrelationid")]
            public Guid? ExternalCorrelationId { get; set; }

            [JsonProperty("internalcorrelationid")]
            public Guid? InternalCorrelationId { get; set; }

            [JsonProperty("log")]
            public string Log { get; set; }

            [JsonProperty("request")]
            public string Request { get; set; }

            [JsonProperty("response")]
            public string Response { get; set; }
        }
    }
}