using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Newtonsoft.Json;

namespace OfficialCommunity.Necropolis.Exceptions
{
    [Serializable]
    public class ContextException : Exception
    {
        private readonly string _context;

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

        public ContextException(string message, object context)
            : base(message)
        {
            if (context != null)
                _context = JsonConvert.SerializeObject(context, Formatting.Indented)
                                    .Replace("\r\n", $"{Environment.NewLine}")
                                    .Replace("\\\"", "\"")
                                    ;
        }

        public ContextException(string message, Exception inner, object context)
            : base(message, inner)
        {
            if (context != null)
                _context = JsonConvert.SerializeObject(context, Formatting.Indented)
                                    .Replace("\r\n", $"{Environment.NewLine}")
                                    .Replace("\\\"", "\"")
                                    ;

        }

        protected ContextException(SerializationInfo info, StreamingContext context, object mycontext)
            : base(info, context)
        {
            if (mycontext != null)
                _context = JsonConvert.SerializeObject(mycontext, Formatting.Indented)
                                    .Replace("\r\n", $"{Environment.NewLine}")
                                    .Replace("\\\"", "\"")
                                    ;

        }

        public string Context => _context;

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("Context", _context);

            base.GetObjectData(info, context);
        }
    }
}
