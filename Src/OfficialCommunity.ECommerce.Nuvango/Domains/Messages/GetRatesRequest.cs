using System.Collections.Generic;
using Newtonsoft.Json;
using OfficialCommunity.ECommerce.Nuvango.Domains.Business;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Messages
{
    public class GetRatesRequest
    {
        [JsonProperty(PropertyName = "currency_code")]
        public string Currency { get; set; }
        [JsonProperty(PropertyName = "ship_address")]
        public Address ShippingAddress { get; set; }
        [JsonProperty(PropertyName = "order_items")]
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
