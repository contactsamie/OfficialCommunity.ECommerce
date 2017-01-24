using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class CheckoutAttribute
    {
        public CheckoutAttribute()
        {
            CheckoutAttributeValue = new HashSet<CheckoutAttributeValue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string TextPrompt { get; set; }
        public bool IsRequired { get; set; }
        public bool ShippableProductRequired { get; set; }
        public bool IsTaxExempt { get; set; }
        public int TaxCategoryId { get; set; }
        public int AttributeControlTypeId { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<CheckoutAttributeValue> CheckoutAttributeValue { get; set; }
    }
}
