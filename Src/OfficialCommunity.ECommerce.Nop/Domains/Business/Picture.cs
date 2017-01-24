using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class Picture
    {
        public Picture()
        {
            ProductPictureMapping = new HashSet<ProductPictureMapping>();
        }

        public int Id { get; set; }
        public byte[] PictureBinary { get; set; }
        public string MimeType { get; set; }
        public string SeoFilename { get; set; }
        public bool IsNew { get; set; }

        public virtual ICollection<ProductPictureMapping> ProductPictureMapping { get; set; }
    }
}
