using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class ManufacturerTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ViewPath { get; set; }
        public int DisplayOrder { get; set; }
    }
}
