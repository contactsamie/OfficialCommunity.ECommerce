﻿using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Nop.Domains.Business
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentItem = new HashSet<ShipmentItem>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public string TrackingNumber { get; set; }
        public decimal? TotalWeight { get; set; }
        public DateTime? ShippedDateUtc { get; set; }
        public DateTime? DeliveryDateUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }

        public virtual ICollection<ShipmentItem> ShipmentItem { get; set; }
        public virtual Order Order { get; set; }
    }
}
