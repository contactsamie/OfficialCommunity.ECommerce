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
        public static string BuildError<T>(this StandardResponse<T> response)
        {
            if (response == null || !response.HasError)
                return null;

            if (response.StandardError.Errors != null && response.StandardError.Errors.Any())
            {
                return string.Join(Environment.NewLine, response.StandardError.Errors);
            }

            return null;
        }

        public static bool LogErrorsIfAny<T>(this StandardResponse<T> response
                                            , string message
                                            , ILogger logger
            )
        {
            if (response == null || !response.HasError)
                return false;

            logger.LogError(message, response.BuildError());

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

            logger.LogError(eventId, message, response.BuildError());

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
