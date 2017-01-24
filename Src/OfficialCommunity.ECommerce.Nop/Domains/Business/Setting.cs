using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class Setting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int StoreId { get; set; }
    }
}
