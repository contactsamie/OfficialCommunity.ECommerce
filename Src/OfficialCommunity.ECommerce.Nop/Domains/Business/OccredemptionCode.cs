using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class OccredemptionCode
    {
        public int Id { get; set; }
        public bool Burned { get; set; }
        public string Code { get; set; }
        public int RedemptionId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public bool Available { get; set; }
    }
}
