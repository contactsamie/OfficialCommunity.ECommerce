using System.Collections.Generic;

namespace OfficialCommunity.Necropolis.Domains.Infrastructure
{
    public class StandardError
    {
        public List<string> Errors { get; private set; }

        public StandardError()
        {
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
