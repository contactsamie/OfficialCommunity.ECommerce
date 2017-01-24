using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class SliderWidget
    {
        public int Id { get; set; }
        public int SliderId { get; set; }
        public string WidgetZone { get; set; }
        public int DisplayOrder { get; set; }

        public virtual AnywhereSlider Slider { get; set; }
    }
}
