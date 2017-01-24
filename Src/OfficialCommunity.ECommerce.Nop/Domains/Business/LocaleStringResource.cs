using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class LocaleStringResource
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceValue { get; set; }

        public virtual Language Language { get; set; }
    }
}
