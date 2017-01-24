using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class Occredemption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeName { get; set; }
        public string InternalProductType { get; set; }
        public string ProductDescription { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public bool IsDigitalDownload { get; set; }
        public string DigitalDownloadPath { get; set; }
        public int LengthOfCode { get; set; }
        public int NumberOfCodes { get; set; }
        public DateTime? StartUtc { get; set; }
        public DateTime? EndUtc { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public bool LimitedToStores { get; set; }
    }
}
