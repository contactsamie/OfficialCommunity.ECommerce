using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficialCommunity.Necropolis.Extensions
{
    public static class StandardResponseExtensions
    {
        private static bool IsHttpStatusCodeOk(int status)
        {
            return (status >= 200 && status <= 299);
        }
        public static string BuildError<T>(this StandardResponse<T> response, string context)
        {
            if (response == null || !response.HasError)
                return null;

            var message = context;

            if (response.StandardError.Exception != null)
            {
                message += Environment.NewLine + response.StandardError.Exception.Message;
            }

            if (response.StandardError.Errors != null && response.StandardError.Errors.Any())
            {
                message += Environment.NewLine + string.Join(Environment.NewLine, response.StandardError.Errors);
            }

            if (!IsHttpStatusCodeOk(response.StandardError.HttpStatusCode))
            {
                message += Environment.NewLine + $"HttpStatus [{response.StandardError.HttpStatusCode}] Reason {response.StandardError.HttpReasonPhrase}";
            }

            return message;
        }

        public static bool LogErrorsIfAny<T>(this StandardResponse<T> response
                                            , string message
                                            , ILogger logger
            )
        {
            if (response == null || !response.HasError)
                return false;

            logger.LogError(message, response.StandardError.Exception);

            return true;
        }

        public static bool LogErrorsIfAny<T>(this StandardResponse<T> response
                                            , string message
                                            , EventId eventId
                                            , ILogger logger
            )
        {
            if (response == null || !response.HasError)
                return false;

            logger.LogError(eventId, response.StandardError.Exception, message);

            return true;
        }

        public static bool LogErrorsIfAny<T>(this StandardResponse<T> response, string context, object log, ILogger logger)
        {
            if (response == null || !response.HasError)
                return false;

            logger.LogError(context
                , string.Join(Environment.NewLine, response.StandardError.Errors)
                , !IsHttpStatusCodeOk(response.StandardError.HttpStatusCode) ? $"HttpStatus [{response.StandardError.HttpStatusCode}] Reason {response.StandardError.HttpReasonPhrase}" : string.Empty
                , log != null ? JsonConvert.SerializeObject(log, Formatting.Indented) : string.Empty
                , response.StandardError.Exception
                );

            return true;
        }

        public static void LogErrorsAndThrow<T>(this StandardResponse<T> response, string context, ILogger logger)
        {
            if (response == null || !response.HasError)
                return;

            var message = context;

            if (response.StandardError.Errors != null && response.StandardError.Errors.Any())
            {
                message += Environment.NewLine + string.Join(Environment.NewLine, response.StandardError.Errors);
            }

            if (!IsHttpStatusCodeOk(response.StandardError.HttpStatusCode))
            {
                message += Environment.NewLine + $"HttpStatus [{response.StandardError.HttpStatusCode}] Reason {response.StandardError.HttpReasonPhrase}";
            }

            logger.LogError(message, response.StandardError.Exception);

            throw new Exception(message, response.StandardError.Exception);
        }

        public static bool CaptureErrorsFrom<TS, TD>(this StandardResponse<TS> destination, StandardResponse<TD> source)
        {
            if (destination == null)
                return false;

            if (source == null || !source.HasError)
                return false;

            if (destination.StandardError == null)
                destination.StandardError = new StandardError();

            if (source.StandardError.Errors != null && source.StandardError.Errors.Any())
            {
                destination.StandardError.Errors.AddRange(source.StandardError.Errors);
            }

            if (!IsHttpStatusCodeOk(source.StandardError.HttpStatusCode))
            {
                destination.StandardError.HttpStatusCode = source.StandardError.HttpStatusCode;
            }

            destination.StandardError.Exception = source.StandardError.Exception;

            return true;
        }

        public static StandardResponse<T> GenerateStandardResponse<T>(this T self)
        {
            var standardError = new StandardError();
            var response = new StandardResponse<T>
            {
                StandardError = standardError,
                Response = self
            };

            return response;
        }

        public static StandardResponse<T> GenerateStandardError<T>(this Exception self)
        {
            var standardError = new StandardError();

            if (self != null)
            {
                standardError.Exception = self;
            }

            var response = new StandardResponse<T>
            {
                StandardError = standardError,
            };

            return response;
        }

        public static StandardResponse<T> GenerateStandardError<T>(this T self, string error)
        {
            var standardError = new StandardError();

            if (!string.IsNullOrWhiteSpace(error))
            {
                standardError.Errors.Add(error);
            }

            var response = new StandardResponse<T>
            {
                StandardError = standardError,
                Response = self
            };

            return response;
        }

        public static StandardResponse<T> GenerateStandardError<T>(this T self, ICollection<string> errors)
        {
            var standardError = new StandardError();

            if (errors != null && errors.Any())
            {
                standardError.Errors.AddRange(errors);
            }

            var response = new StandardResponse<T>
            {
                StandardError = standardError,
                Response = self
            };

            return response;
        }
    }
}
