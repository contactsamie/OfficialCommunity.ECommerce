using System;
using Microsoft.ApplicationInsights.Channel;
using Serilog.Events;
using Serilog.ExtensionMethods;

namespace OfficialCommunity.Necropolis.Console
{
    public static class SerilogHelpers
    {
        public static ITelemetry ConvertLogEventsToCustomTraceTelemetry(LogEvent logEvent, IFormatProvider formatProvider)
        {
            ITelemetry telemetry = null;

            if (logEvent.Exception == null)
            {
                var traceTelemetry = logEvent.ToDefaultTraceTelemetry(
                    formatProvider,
                    includeLogLevelAsProperty: true,
                    includeRenderedMessageAsProperty: false,
                    includeMessageTemplateAsProperty: false);

                if (logEvent.Properties.ContainsKey("UserId"))
                {
                    traceTelemetry.Context.User.Id = logEvent.Properties["UserId"].ToString();
                }

                if (traceTelemetry.Properties.ContainsKey("UserId"))
                {
                    traceTelemetry.Properties.Remove("UserId");
                }

                telemetry = traceTelemetry;
            }
            else
            {
                var exceptionTelemetry = logEvent.ToDefaultExceptionTelemetry(
                    formatProvider,
                    includeLogLevelAsProperty: true,
                    includeRenderedMessageAsProperty: false,
                    includeMessageTemplateAsProperty: false);

                if (logEvent.Properties.ContainsKey("UserId"))
                {
                    exceptionTelemetry.Context.User.Id = logEvent.Properties["UserId"].ToString();

                    if (exceptionTelemetry.Properties.ContainsKey("UserId"))
                    {
                        exceptionTelemetry.Properties.Remove("UserId");
                    }
                }

                telemetry = exceptionTelemetry;
            }

            return telemetry;
        }
    }
}
