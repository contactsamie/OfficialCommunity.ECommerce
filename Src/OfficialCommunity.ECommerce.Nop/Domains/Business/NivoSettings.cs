using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class NivoSettings
    {
        public int Id { get; set; }
        public int SliderId { get; set; }
        public int AutoSlideInterval { get; set; }
        public int AnimationSpeed { get; set; }
        public bool EnableDirectionNavigation { get; set; }
        public bool DirectionNavigationShowOnHoverOnly { get; set; }
        public bool KeyboardNavigation { get; set; }
        public bool EnableControlNavigation { get; set; }
        public bool EnableControlNavigationThumbs { get; set; }
        public int ThumbsBiggerSize { get; set; }
        public float CaptionOpacity { get; set; }
        public string PrevText { get; set; }
        public string NextText { get; set; }
        public bool Links { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool PauseOnHover { get; set; }
        public bool ShowCaption { get; set; }
        public string Effect { get; set; }
        public int Slices { get; set; }
        public int BoxCols { get; set; }
        public int BoxRows { get; set; }
        public string Theme { get; set; }
        public bool RandomStart { get; set; }

        public virtual AnywhereSlider Slider { get; set; }
    }
}
