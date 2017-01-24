﻿using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class SpecificationAttributeOption
    {
        public SpecificationAttributeOption()
        {
            ProductSpecificationAttributeMapping = new HashSet<ProductSpecificationAttributeMapping>();
        }

        public int Id { get; set; }
        public int SpecificationAttributeId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<ProductSpecificationAttributeMapping> ProductSpecificationAttributeMapping { get; set; }
        public virtual SpecificationAttribute SpecificationAttribute { get; set; }
    }
}
