using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class DiscountAppliedToProducts
    {
        public int DiscountId { get; set; }
        public int ProductId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Product Product { get; set; }
    }
}
