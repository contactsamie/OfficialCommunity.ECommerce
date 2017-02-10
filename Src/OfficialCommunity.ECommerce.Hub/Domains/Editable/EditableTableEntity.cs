using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfficialCommunity.ECommerce.Hub.Domains.Editable
{
    public abstract class EditableTableEntity
    {
        public string PartitionKey { get; set; }

        public string RowKey { get; set; }

        public Guid Id { get; set; }

        public bool Deleted { get; set; }

        public bool Published { get; set; }

        public DateTime CreatedUtc { get; set; }

        public string CreatedBy { get; set; }

        public DateTime LastUpdatedUtc { get; set; }

        public string LastUpdatedBy { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ProviderName { get; set; }

        [Required]
        public Guid ProviderKey { get; set; }

        public List<EditableConfiguration> ProviderConfiguration { get; set; }
    }
}