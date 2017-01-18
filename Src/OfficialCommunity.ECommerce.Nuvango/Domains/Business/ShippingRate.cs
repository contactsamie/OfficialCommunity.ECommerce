using RestSharp.Deserializers;
using RestSharp.Serializers;

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

        [SerializeAs(Name = "carrier")]
        [DeserializeAs(Name = "carrier")]
        public string Carrier { get; set; }

        [SerializeAs(Name = "title")]
        [DeserializeAs(Name = "title")]
        public string Title { get; set; }

        [SerializeAs(Name = "code")]
        [DeserializeAs(Name = "code")]
        public string Code { get; set; }

        [SerializeAs(Name = "price")]
        [DeserializeAs(Name = "price")]
        public decimal Price { get; set; }
    }
}