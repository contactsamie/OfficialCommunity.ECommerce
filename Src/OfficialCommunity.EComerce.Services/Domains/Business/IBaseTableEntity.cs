using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Services.Domains.Business
{
    public interface IBaseTableEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedUtc { get; set; }
        bool Deleted { get; set; }
        string Description { get; set; }
        Guid Id { get; set; }
        string LastUpdatedBy { get; set; }
        DateTime LastUpdatedUtc { get; set; }
        string Name { get; set; }
        Dictionary<string, string> ProviderConfiguration { get; set; }
        Guid ProviderKey { get; set; }
        string ProviderName { get; set; }
    }
}