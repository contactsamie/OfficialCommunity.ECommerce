using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class OccsubscriptionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid SubscriptionTypeGuid { get; set; }
        public string Description { get; set; }
        public bool IsGift { get; set; }
        public int? GiftProductId { get; set; }
        public int NumberOfDays { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int RoleId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public bool LimitedToStores { get; set; }
    }
}
