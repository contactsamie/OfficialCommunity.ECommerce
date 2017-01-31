using System.Collections.Generic;

namespace OfficialCommunity.Necropolis.DocumentDB.Domains.Infrastructure
{
    public class PagedResults<T>
    {
        public PagedResults()
        {
            Results = new List<T>();
        }

        public string ContinuationToken { get; set; }

        public List<T> Results { get; set; }
    }
}
