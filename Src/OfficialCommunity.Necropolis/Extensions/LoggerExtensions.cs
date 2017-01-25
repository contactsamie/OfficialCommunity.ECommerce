using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;

namespace OfficialCommunity.Necropolis.Extensions
{
    public static class LoggerExtensions
    {
        private static readonly Func<object, Exception, string> _messageFormatter = MessageFormatter;

        /// <summary>
        /// Formats and writes an error log message.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to write to.</param>
        /// <param name="exception">The exception to log.</param>
        /// <param name="message">Format string of the log message.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        public static void LogError(this ILogger logger, Exception exception, string message, params object[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            logger.Log(LogLevel.Error, 0, new FormattedLogValues(message, args), exception, _messageFormatter);
        }

        //------------------------------------------HELPERS------------------------------------------//

        private static string MessageFormatter(object state, Exception error)
        {
            return state.ToString();
        }
    }
}