using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class Store
    {
        public Store()
        {
            StoreMapping = new HashSet<StoreMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool SslEnabled { get; set; }
        public string SecureUrl { get; set; }
        public string Hosts { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<StoreMapping> StoreMapping { get; set; }
    }
}
