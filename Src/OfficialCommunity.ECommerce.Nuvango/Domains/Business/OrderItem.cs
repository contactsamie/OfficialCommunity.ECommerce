using Newtonsoft.Json;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Business
{
    public class OrderItem 
    {
        public static OrderItem From(ECommerce.Domains.Business.BasketLine basketLine)
        {
            return new OrderItem
            {
                Id = int.Parse(basketLine.Sku),
                Quantity = basketLine.Quantity
            };
        }

        public static ECommerce.Domains.Business.BasketLine To(OrderItem orderItem)
        {
            return new ECommerce.Domains.Business.BasketLine
            {
                Sku = orderItem.Id.ToString(),
                Quantity = orderItem.Quantity
            };
        }

        [JsonProperty(PropertyName = "variant_id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "unit_price")]
        public decimal UnitPrice { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
}
