using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class ShippingByWeight
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int CountryId { get; set; }
        public int StateProvinceId { get; set; }
        public string Zip { get; set; }
        public int ShippingMethodId { get; set; }
        public decimal From { get; set; }
        public decimal To { get; set; }
        public decimal AdditionalFixedCost { get; set; }
        public decimal PercentageRateOfSubtotal { get; set; }
        public decimal RatePerWeightUnit { get; set; }
        public decimal LowerWeightLimit { get; set; }
    }
}
