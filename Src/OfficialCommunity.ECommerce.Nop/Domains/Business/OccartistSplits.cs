using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class OccartistSplits
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string ProductType { get; set; }
        public int Gross { get; set; }
        public int ArtistNet { get; set; }
        public int Occnet { get; set; }
    }
}
