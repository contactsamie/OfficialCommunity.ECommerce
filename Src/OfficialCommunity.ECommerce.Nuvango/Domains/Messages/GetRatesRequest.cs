using System.Collections.Generic;
using Newtonsoft.Json;
using OfficialCommunity.ECommerce.Nuvango.Domains.Business;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Messages
{
    public class GetRatesRequest
    {
        [JsonProperty(PropertyName = "currency_code")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "zip")]
        public string Zip { get; set; }

        [JsonProperty(PropertyName = "order_items")]
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
