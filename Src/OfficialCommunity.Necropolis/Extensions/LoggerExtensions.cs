using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.Necropolis.Extensions
{
    public static class LoggerExtensions
    {
        private static readonly Func<object, Exception, string> _messageFormatter = MessageFormatter;

        public static void LogError<T>(this ILogger logger, string message, IStandardResponse<T> standardResponse)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Error, 0, new FormattedLogValues(message + Environment.NewLine + standardResponse.BuildError(), null), null, _messageFormatter);
        }

        public static void LogError(this ILogger logger, Exception exception, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Error, 0, new FormattedLogValues(message, null), exception, _messageFormatter);
        }

        public static void LogError(this ILogger logger, Exception exception, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Error, 0, new FormattedLogValues(message, args), exception, _messageFormatter);
        }

        private static string MessageFormatter(object state, Exception error)
        {
            return state.ToString();
        }
    }
}