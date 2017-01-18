using System.Linq;

namespace OfficialCommunity.Necropolis.Domains.Infrastructure
{
    public class StandardResponse<T> : IStandardResponse<T>
    {
        public StandardError StandardError { get; set; }

        public T Response { get; set; }

        public bool HasError => StandardError.Errors != null && StandardError.Errors.Any();
    }
}
