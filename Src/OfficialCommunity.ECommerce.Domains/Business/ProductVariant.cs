using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Domains.Business
{
    public class ProductVariant : Base
    {
        public List<ProductOption> Options { get; set; }
    }
}
