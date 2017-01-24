using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class AnywhereSlider
    {
        public AnywhereSlider()
        {
            Carousel3Dsettings = new HashSet<Carousel3Dsettings>();
            CarouselSettings = new HashSet<CarouselSettings>();
            NivoSettings = new HashSet<NivoSettings>();
            SliderCategory = new HashSet<SliderCategory>();
            SliderImage = new HashSet<SliderImage>();
            SliderManufacturer = new HashSet<SliderManufacturer>();
            SliderWidget = new HashSet<SliderWidget>();
        }

        public int Id { get; set; }
        public string SystemName { get; set; }
        public int SliderType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int LanguageId { get; set; }
        public bool LimitedToStores { get; set; }

        public virtual ICollection<Carousel3Dsettings> Carousel3Dsettings { get; set; }
        public virtual ICollection<CarouselSettings> CarouselSettings { get; set; }
        public virtual ICollection<NivoSettings> NivoSettings { get; set; }
        public virtual ICollection<SliderCategory> SliderCategory { get; set; }
        public virtual ICollection<SliderImage> SliderImage { get; set; }
        public virtual ICollection<SliderManufacturer> SliderManufacturer { get; set; }
        public virtual ICollection<SliderWidget> SliderWidget { get; set; }
    }
}
