using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class ActivityLog
    {
        public int Id { get; set; }
        public int ActivityLogTypeId { get; set; }
        public int CustomerId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual ActivityLogType ActivityLogType { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
