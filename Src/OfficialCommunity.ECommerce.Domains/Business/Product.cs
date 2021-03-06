﻿using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Domains.Business
{
    public class Product : Base
    {
        public string Name { get; set; }
        public List<ProductOption> Options { get; set; }
        public List<ProductVariant> Variants { get; set; }
    }
}
