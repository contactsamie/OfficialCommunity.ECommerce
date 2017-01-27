using Newtonsoft.Json;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Business
{
    public class CartItem
    {
        [JsonProperty(PropertyName = "variant_id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
}