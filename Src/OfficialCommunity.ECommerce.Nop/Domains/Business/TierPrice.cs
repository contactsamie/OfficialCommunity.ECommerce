using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class TierPrice
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int? CustomerRoleId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual CustomerRole CustomerRole { get; set; }
        public virtual Product Product { get; set; }
    }
}
