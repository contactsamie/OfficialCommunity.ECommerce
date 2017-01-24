using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class Affiliate
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }

        public virtual Address Address { get; set; }
    }
}
