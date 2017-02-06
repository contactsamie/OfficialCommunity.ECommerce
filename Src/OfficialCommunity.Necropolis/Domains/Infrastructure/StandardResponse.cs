using System.Linq;

namespace OfficialCommunity.Necropolis.Domains.Infrastructure
{
    public class StandardResponse<T> : IStandardResponse<T>
    {
        public IStandardError StandardError { get; set; }

        public T Response { get; set; }

        public bool HasError => StandardError.Errors != null && StandardError.Errors.Any();
    }
}
