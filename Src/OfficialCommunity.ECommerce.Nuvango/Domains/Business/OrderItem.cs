using RestSharp.Deserializers;
using RestSharp.Serializers;

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

        [SerializeAs(Name = "variant_id")]
        [DeserializeAs(Name = "variant_id")]
        public int Id { get; set; }

        [SerializeAs(Name = "unit_price")]
        [DeserializeAs(Name = "unit_price")]
        public decimal UnitPrice { get; set; }

        [SerializeAs(Name = "quantity")]
        [DeserializeAs(Name = "quantity")]
        public int Quantity { get; set; }
    }
}
