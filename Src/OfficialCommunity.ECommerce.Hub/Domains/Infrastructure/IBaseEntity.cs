using System;

namespace OfficialCommunity.ECommerce.Hub.Domains.Infrastructure
{
    public interface IBaseEntity
    {
        // ReSharper disable once InconsistentNaming
        Guid Id { get; set; }
        byte[] RowVersion { get; set; }
        DateTime? CreatedUtc { get; set; }
        string CreatedBy { get; set; }
        string MachineName { get; set; }
    }
}