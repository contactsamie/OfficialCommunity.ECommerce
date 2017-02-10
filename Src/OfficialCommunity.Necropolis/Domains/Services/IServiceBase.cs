using System;

namespace OfficialCommunity.Necropolis.Domains.Services
{
    public interface IServiceBase
    {
        string Name { get; }
        Guid Key { get; }
    }
}