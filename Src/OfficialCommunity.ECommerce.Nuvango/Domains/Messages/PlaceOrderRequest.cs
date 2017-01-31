using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OfficialCommunity.ECommerce.Nuvango.Domains.Business;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Messages
{
    public class PlaceOrderRequest
    {
        [JsonProperty(PropertyName = "order_number")]
        public string OrderNumber { get; set; }

        [JsonProperty(PropertyName = "order_timestamp")]
        public DateTime TimeStampUtc { get; set; }

        [JsonProperty(PropertyName = "order_currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "total_tax")]
        public decimal Tax { get; set; }

        [JsonProperty(PropertyName = "subtotal_price")]
        public decimal SubtotalPrice { get; set; }

        [JsonProperty(PropertyName = "total_discounts")]
        public decimal Discounts { get; set; }

        [JsonProperty(PropertyName = "total_price")]
        public decimal TotalPrice { get; set; }

        //-------------------------------------------------

        [JsonProperty(PropertyName = "customer")]
        public Customer Customer { get; set; }

        [JsonProperty(PropertyName = "ship_address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "shipping")]
        public ShippingRate ShippingRate { get; set; }

        [JsonProperty(PropertyName = "line_items")]
        public IList<OrderItem> OrderItems { get; set; }
    }
}