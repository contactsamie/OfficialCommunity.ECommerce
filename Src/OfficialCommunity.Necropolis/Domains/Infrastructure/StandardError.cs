using System;
using System.Collections.Generic;

namespace OfficialCommunity.Necropolis.Domains.Infrastructure
{
    public class StandardError
    {
        public string Url { get; set; }
        public int HttpStatusCode { get; set; }
        public string HttpReasonPhrase { get; set; }
        public Exception Exception { get; set; }
        public List<string> Errors { get; private set; }

        public StandardError(string url = "", int httpStatusCode = 200, string httpReasonPhrase = "OK")
        {
            Url = url;
            HttpStatusCode = httpStatusCode;
            HttpReasonPhrase = httpReasonPhrase;
            Errors = new List<string>();
        }

        public void Error(string error)
        {
            Errors.Add(error);
        }

        public void Error(IEnumerable<string> errors)
        {
            Errors.AddRange(errors);
        }
    }
}
