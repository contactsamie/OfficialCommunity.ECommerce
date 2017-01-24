using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class SliderCategory
    {
        public int Id { get; set; }
        public int SliderId { get; set; }
        public int CategoryId { get; set; }

        public virtual AnywhereSlider Slider { get; set; }
    }
}
