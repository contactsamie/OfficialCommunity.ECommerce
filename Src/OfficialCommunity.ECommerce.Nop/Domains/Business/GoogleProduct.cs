using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class GoogleProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Taxonomy { get; set; }
        public string Gender { get; set; }
        public string AgeGroup { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Pattern { get; set; }
        public string ItemGroupId { get; set; }
    }
}
