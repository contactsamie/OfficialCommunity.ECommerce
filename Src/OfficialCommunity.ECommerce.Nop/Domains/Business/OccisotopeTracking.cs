using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class OccisotopeTracking
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string FileName { get; set; }
        public bool Success { get; set; }
        public int NumberOfItems { get; set; }
        public string ShortMessage { get; set; }
        public string FullMessage { get; set; }
        public DateTime TransferUtc { get; set; }
        public int SequenceNumber { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
