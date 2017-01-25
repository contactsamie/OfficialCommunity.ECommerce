using ExpressMapper;
using Newtonsoft.Json;
using NUnit.Framework;
using Common = OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class ShippingRateMappings : MappingsBase
    {
        [Test]
        public void when_nuvango_shippingrate_is_mapped_to_common_shippingrate()
        {
            var shippingRate =
                Mapper.Map<Domains.Business.ShippingRate, Common.ShippingRate>(Nuvango.ShippingRate.Test);

            Assert.AreEqual(shippingRate.Name, $"{Nuvango.ShippingRate.Test.Carrier}:{Nuvango.ShippingRate.Test.Title}:{Nuvango.ShippingRate.Test.Code}");
            Assert.AreEqual(shippingRate.Price, Nuvango.ShippingRate.Test.Price);
            Assert.AreEqual(shippingRate.Currency, Nuvango.ShippingRate.Test.Currency);
            Assert.AreEqual(shippingRate.Json, JsonConvert.SerializeObject(Nuvango.ShippingRate.Test));
        }

        [Test]
        public void when_common_shippingrate_is_mapped_to_nuvango_shippingrate()
        {
            var shippingRate =
                Mapper.Map<Common.ShippingRate, Domains.Business.ShippingRate>(TestData.ShippingRate.Test);
            var deserializedShippingRate =
                JsonConvert.DeserializeObject<Domains.Business.ShippingRate>(TestData.ShippingRate.Test.Json);

            Assert.AreEqual(shippingRate.Carrier, deserializedShippingRate.Carrier);
            Assert.AreEqual(shippingRate.Title, deserializedShippingRate.Title);
            Assert.AreEqual(shippingRate.Code, deserializedShippingRate.Code);
            Assert.AreEqual(shippingRate.Price, deserializedShippingRate.Price);
            Assert.AreEqual(shippingRate.Currency, deserializedShippingRate.Currency);
        }
    }
}
