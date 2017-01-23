using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficialCommunity.ECommerce.Hub.Domains.Infrastructure
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Timestamp]
        [ConcurrencyCheck]
        public byte[] RowVersion { get; set; }
        public DateTime? CreatedUtc { get; set; }
        public string CreatedBy { get; set; }
        public string MachineName { get; set; }
    }
}