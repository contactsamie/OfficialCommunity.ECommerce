using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class RewardPointsHistory
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Points { get; set; }
        public int PointsBalance { get; set; }
        public decimal UsedAmount { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int? UsedWithOrderId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order UsedWithOrder { get; set; }
    }
}
