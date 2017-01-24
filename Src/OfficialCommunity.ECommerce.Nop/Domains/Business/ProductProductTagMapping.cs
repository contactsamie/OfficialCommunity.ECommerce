using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class ProductProductTagMapping
    {
        public int ProductId { get; set; }
        public int ProductTagId { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductTag ProductTag { get; set; }
    }
}
