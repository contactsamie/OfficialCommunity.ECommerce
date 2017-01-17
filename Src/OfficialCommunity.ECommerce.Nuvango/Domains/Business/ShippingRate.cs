using Newtonsoft.Json;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Business
{
    public class ShippingRate
    {
        public static ShippingRate From(ECommerce.Domains.Business.ShippingRate shippingRate)
        {
            return new ShippingRate
            {
                Carrier = shippingRate.Carrier,
                Title = shippingRate.Title,
                Code = shippingRate.Code,
                Price = shippingRate.Price
            };
        }

        public static ECommerce.Domains.Business.ShippingRate To(ShippingRate shippingRate)
        {
            return new ECommerce.Domains.Business.ShippingRate
            {
                Carrier = shippingRate.Carrier,
                Title = shippingRate.Title,
                Code = shippingRate.Code,
                Price = shippingRate.Price
            };
        }

        [JsonProperty(PropertyName = "carrier")]
        public string Carrier { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }
    }
}