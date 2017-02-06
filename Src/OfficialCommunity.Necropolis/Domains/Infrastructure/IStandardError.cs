using System.Collections.Generic;

namespace OfficialCommunity.Necropolis.Domains.Infrastructure
{
    public interface IStandardError
    {
        IList<string> Errors { get; }
    }
}