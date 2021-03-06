﻿using System.Net;
using RestSharp;

namespace OfficialCommunity.ECommerce.Nuvango.Extensions
{
    public static class RestSharpExtensionMethods
    {
        public static bool IsSuccessful(this IRestResponse response)
        {
            return response.StatusCode.IsSuccessStatusCode()
                && response.ResponseStatus == ResponseStatus.Completed;
        }

        public static bool IsSuccessStatusCode(this HttpStatusCode responseCode)
        {
            var numericResponse = (int)responseCode;
            return numericResponse >= 200
                && numericResponse <= 399;
        }
    }
}
