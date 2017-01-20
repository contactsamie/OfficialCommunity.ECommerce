using Newtonsoft.Json;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Business
{
    public class OrderItem 
    {
        [JsonProperty(PropertyName = "variant_id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "unit_price")]
        public decimal UnitPrice { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
}
