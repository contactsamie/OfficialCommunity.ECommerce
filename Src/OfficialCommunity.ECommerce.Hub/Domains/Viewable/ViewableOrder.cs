using System;
using System.Collections.Generic;
using OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Hub.Domains.Viewable
{
    public class ViewableOrder
    {
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

        public ViewableCustomer Customer { get; set; }
        public ViewableAddress ShippingAddress { get; set; }
        public ViewableShippingRate ShippingRate { get; set; }
        public IList<ViewableOrderItem> OrderItems { get; set; }
    }
}