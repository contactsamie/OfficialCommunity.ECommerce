using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Business
{
    public class Product 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ProductOption> Options { get; set; }

        public List<ProductVariant> Variants { get; set; }
    }
}