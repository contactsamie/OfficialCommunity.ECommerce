using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class OccisotopeItemTracking
    {
        public int Id { get; set; }
        public int IsotopeTrackingId { get; set; }
        public int OrderItemId { get; set; }
    }
}
