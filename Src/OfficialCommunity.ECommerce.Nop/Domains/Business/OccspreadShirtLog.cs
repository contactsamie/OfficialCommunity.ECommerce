using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class OccspreadShirtLog
    {
        public int Id { get; set; }
        public int LogLevelId { get; set; }
        public string ShortMessage { get; set; }
        public string FullMessage { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
