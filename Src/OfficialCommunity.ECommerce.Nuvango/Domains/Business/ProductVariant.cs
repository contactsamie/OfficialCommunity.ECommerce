using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Business
{
    public class ProductVariant 
    {
        public int Id { get; set; }

        public List<ProductOption> Options { get; set; }
    }
}