using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class Jcarousel
    {
        public Jcarousel()
        {
            JcarouselCategory = new HashSet<JcarouselCategory>();
            JcarouselManufacturer = new HashSet<JcarouselManufacturer>();
            JcarouselProduct = new HashSet<JcarouselProduct>();
            JcarouselWidget = new HashSet<JcarouselWidget>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int NumberOfItems { get; set; }
        public int NumberOfVisibleItems { get; set; }
        public string DataSourceType { get; set; }
        public string Skin { get; set; }
        public int ImageSize { get; set; }
        public bool ShowItemsName { get; set; }
        public bool ShowTitle { get; set; }
        public bool ShowProdictsPrice { get; set; }
        public bool ShowProdictsOldPrice { get; set; }
        public bool ShowShortDescription { get; set; }
        public bool ShowDetailsButton { get; set; }
        public bool CarouselOrientation { get; set; }
        public bool RightToLeft { get; set; }
        public int StartIndex { get; set; }
        public int ScrollItems { get; set; }
        public string Easing { get; set; }
        public int Autoscroll { get; set; }
        public string WrapItems { get; set; }
        public string AnimationSpeed { get; set; }
        public bool LimitedToStores { get; set; }

        public virtual ICollection<JcarouselCategory> JcarouselCategory { get; set; }
        public virtual ICollection<JcarouselManufacturer> JcarouselManufacturer { get; set; }
        public virtual ICollection<JcarouselProduct> JcarouselProduct { get; set; }
        public virtual ICollection<JcarouselWidget> JcarouselWidget { get; set; }
    }
}
