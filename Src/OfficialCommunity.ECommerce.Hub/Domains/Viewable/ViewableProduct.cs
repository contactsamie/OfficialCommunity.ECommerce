using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Hub.Domains.Viewable
{
    public class ViewableProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ViewableProductVariant> Variants { get; set; }
    }
}