﻿using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class JcarouselWidget
    {
        public int Id { get; set; }
        public int CarouselId { get; set; }
        public string WidgetZone { get; set; }
        public int DisplayOrder { get; set; }

        public virtual Jcarousel Carousel { get; set; }
    }
}
