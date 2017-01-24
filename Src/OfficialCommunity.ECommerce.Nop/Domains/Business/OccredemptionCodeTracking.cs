using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class OccredemptionCodeTracking
    {
        public int Id { get; set; }
        public int RedemptionCodeTrackingId { get; set; }
        public string Code { get; set; }
        public int CodeId { get; set; }
    }
}
