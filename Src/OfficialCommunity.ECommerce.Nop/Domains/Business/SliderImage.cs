using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class SliderImage
    {
        public int Id { get; set; }
        public string DisplayText { get; set; }
        public string Url { get; set; }
        public string Alt { get; set; }
        public bool Visible { get; set; }
        public int DisplayOrder { get; set; }
        public int PictureId { get; set; }
        public int SliderId { get; set; }

        public virtual AnywhereSlider Slider { get; set; }
    }
}
