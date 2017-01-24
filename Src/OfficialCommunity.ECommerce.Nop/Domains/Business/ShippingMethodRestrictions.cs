using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class ShippingMethodRestrictions
    {
        public int ShippingMethodId { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ShippingMethod ShippingMethod { get; set; }
    }
}
