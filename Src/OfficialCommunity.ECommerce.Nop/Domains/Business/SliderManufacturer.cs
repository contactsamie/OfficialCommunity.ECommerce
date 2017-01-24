using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class SliderManufacturer
    {
        public int Id { get; set; }
        public int SliderId { get; set; }
        public int ManufacturerId { get; set; }

        public virtual AnywhereSlider Slider { get; set; }
    }
}
