using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class Carousel3Dsettings
    {
        public int Id { get; set; }
        public int SliderId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int PictureWidth { get; set; }
        public int PictureHeight { get; set; }
        public int Yradius { get; set; }
        public int Xposition { get; set; }
        public int Yposition { get; set; }
        public double Speed { get; set; }
        public double MouseWheel { get; set; }
        public int AutoRotateDelay { get; set; }
        public bool AutoRotate { get; set; }

        public virtual AnywhereSlider Slider { get; set; }
    }
}
