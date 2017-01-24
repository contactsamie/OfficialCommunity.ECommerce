using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class CarouselSettings
    {
        public int Id { get; set; }
        public int SliderId { get; set; }
        public int AutoSlideInterval { get; set; }
        public bool Navigation { get; set; }
        public bool Links { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool HoverPause { get; set; }
        public bool ShowTitle { get; set; }

        public virtual AnywhereSlider Slider { get; set; }
    }
}
