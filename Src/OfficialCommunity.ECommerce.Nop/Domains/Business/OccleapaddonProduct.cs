using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class OccleapaddonProduct
    {
        public OccleapaddonProduct()
        {
            OccleapliveEventAddon = new HashSet<OccleapliveEventAddon>();
        }

        public int Id { get; set; }
        public Guid AddonProductGuid { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public string LeappropertyName { get; set; }
        public string LeappropertyId { get; set; }
        public string LeapproductId { get; set; }
        public string Leapsku { get; set; }
        public string Leapname { get; set; }
        public string Leapdescription { get; set; }
        public string LeapimageUrl { get; set; }
        public decimal LeappriceCad { get; set; }
        public decimal LeappriceUsd { get; set; }
        public decimal LeappriceEur { get; set; }
        public decimal LeappriceGbp { get; set; }

        public virtual ICollection<OccleapliveEventAddon> OccleapliveEventAddon { get; set; }
    }
}
