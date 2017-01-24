using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class TaxRate
    {
        public int Id { get; set; }
        public int TaxCategoryId { get; set; }
        public int CountryId { get; set; }
        public int StateProvinceId { get; set; }
        public string Zip { get; set; }
        public decimal Percentage { get; set; }
    }
}
