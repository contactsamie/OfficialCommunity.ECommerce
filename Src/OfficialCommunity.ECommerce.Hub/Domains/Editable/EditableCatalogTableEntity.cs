﻿using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Hub.Domains.Editable
{
    public class EditableCatalogTableEntity
    {
        public Guid Id { get; set; }

        public bool Deleted { get; set; }

        public bool Published { get; set; }

        public DateTime CreatedUtc { get; set; }
        
        public string CreatedBy { get; set; }
        
        public DateTime LastUpdatedUtc { get; set; }
        
        public string LastUpdatedBy { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ProviderName { get; set; }

        public string ProviderKey { get; set; }

        public List<EditableConfiguration> ProviderConfiguration { get; set; }
    }
}
