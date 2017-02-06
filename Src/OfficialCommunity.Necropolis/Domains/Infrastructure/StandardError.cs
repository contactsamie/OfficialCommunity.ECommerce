using System.Collections.Generic;

namespace OfficialCommunity.Necropolis.Domains.Infrastructure
{
    public class StandardError : IStandardError
    {
        private readonly List<string> _errors;

        public IList<string> Errors => _errors;

        public StandardError()
        {
            _errors = new List<string>();
        }

        public void Error(string error)
        {
            _errors.Add(error);
        }

        public void Error(IEnumerable<string> errors)
        {
            _errors.AddRange(errors);
        }
    }
}
