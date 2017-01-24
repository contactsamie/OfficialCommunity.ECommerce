using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class ProductProductAttributeMapping
    {
        public ProductProductAttributeMapping()
        {
            ProductVariantAttributeValue = new HashSet<ProductVariantAttributeValue>();
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductAttributeId { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public int AttributeControlTypeId { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<ProductVariantAttributeValue> ProductVariantAttributeValue { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }
        public virtual Product Product { get; set; }
    }
}
