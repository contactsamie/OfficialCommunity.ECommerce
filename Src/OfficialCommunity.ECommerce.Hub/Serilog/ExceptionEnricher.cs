using AsyncFriendlyStackTrace;
using Serilog.Core;
using Serilog.Events;

namespace OfficialCommunity.ECommerce.Hub.Serilog
{
    public class ExceptionEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent.Exception != null)
            {
                logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("System.Exception", logEvent.Exception.ToAsyncString()));
            }
        }
    }
}
