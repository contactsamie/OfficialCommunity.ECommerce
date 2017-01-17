using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Newtonsoft.Json;

namespace OfficialCommunity.Necropolis.Exceptions
{
    [Serializable]
    public class ContextException : Exception
    {
        private readonly string _log;

        public ContextException()
        {
        }

        public ContextException(string message)
            : base(message)
        {
        }

        public ContextException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ContextException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ContextException(string message, object log)
            : base(message)
        {
            if (log != null)
                _log = JsonConvert.SerializeObject(log, Formatting.Indented)
                                    .Replace("\r\n", $"{Environment.NewLine}")
                                    .Replace("\\\"", "\"")
                                    ;
        }

        public ContextException(string message, Exception inner, object log)
            : base(message, inner)
        {
            if (log != null)
                _log = JsonConvert.SerializeObject(log, Formatting.Indented)
                                    .Replace("\r\n", $"{Environment.NewLine}")
                                    .Replace("\\\"", "\"")
                                    ;

        }

        protected ContextException(SerializationInfo info, StreamingContext context, object log)
            : base(info, context)
        {
            if (log != null)
                _log = JsonConvert.SerializeObject(log, Formatting.Indented)
                                    .Replace("\r\n", $"{Environment.NewLine}")
                                    .Replace("\\\"", "\"")
                                    ;

        }

        public string Log => _log;

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("Log", _log);

            base.GetObjectData(info, context);
        }
    }
}
