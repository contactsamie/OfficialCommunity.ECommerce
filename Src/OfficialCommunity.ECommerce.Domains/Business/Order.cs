using System;
using System.Collections.Generic;

namespace OfficialCommunity.ECommerce.Domains.Business
{
    public class Order 
    {
        // System name of store provider.
        // Example: nop, bigcommerce
        public string StoreProvider { get; set; }

        public string StoreOrderId { get; set; }
        public string FufillmentOrderId { get; set; }

        public DateTime TimeStampUtc { get; set; }
        public ShippingState ShippingState { get; set; }
        public string Currency { get; set; }
        public decimal Tax { get; set; }
        public decimal SubtotalPrice { get; set; }
        public decimal Discounts { get; set; }
        public decimal TotalPrice { get; set; }

        public Store Store { get; set; }

        public Customer Customer { get; set; }
        public Address ShippingAddress { get; set; }
        public ShippingRate ShippingRate { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }
}
