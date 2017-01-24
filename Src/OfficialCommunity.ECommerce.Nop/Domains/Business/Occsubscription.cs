using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class Occsubscription
    {
        public int Id { get; set; }
        public Guid SubscriptionGuid { get; set; }
        public int SubscriptionTypeId { get; set; }
        public Guid SubscriptionTypeGuid { get; set; }
        public int CustomerId { get; set; }
        public Guid CustomerGuid { get; set; }
        public string Notes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public bool LimitedToStores { get; set; }
        public bool Retired { get; set; }
    }
}
