using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Domains.Business
{
    public class Cart
    {
        public string StoreOrderId { get; set; }
        public DateTime TimeStampUtc { get; set; }

        public string Currency { get; set; }
        public decimal Tax { get; set; }
        public decimal SubtotalPrice { get; set; }
        public decimal Discounts { get; set; }
        public decimal TotalPrice { get; set; }

        public Customer Customer { get; set; }
        public Address ShippingAddress { get; set; }
        public ShippingRate ShippingRate { get; set; }
        public IList<CartItem> Items { get; set; }
    }
}