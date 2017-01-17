using System.Linq;

namespace OfficialCommunity.Necropolis.Domains.Infrastructure
{
    public class StandardResponse<T> : IStandardResponse<T>
    {
        public StandardError StandardError { get; set; }

        public T Response { get; set; }

        public bool HasError
        {
            get
            {
                return (StandardError != null
                        && (StandardError.Exception != null
                            || (StandardError.Errors != null && StandardError.Errors.Any())
                            || (StandardError.HttpStatusCode < 200 && StandardError.HttpStatusCode > 299)));
            }
        }
    }
}
