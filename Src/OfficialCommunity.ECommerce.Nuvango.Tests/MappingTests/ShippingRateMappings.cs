using ExpressMapper;
using NUnit.Framework;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class ShippingRateMappings : MappingsBase
    {
        [Test]
        public void when_nuvango_shippingrate_is_mapped_to_common_shippingrate()
        {
            var shippingRate =
                Mapper.Map<Domains.Business.ShippingRate, ECommerce.Domains.Business.ShippingRate>(Nuvango.ShippingRate.Test);

            Assert.AreEqual(shippingRate.Carrier, Nuvango.ShippingRate.Test.Carrier);
            Assert.AreEqual(shippingRate.Title, Nuvango.ShippingRate.Test.Title);
            Assert.AreEqual(shippingRate.Code, Nuvango.ShippingRate.Test.Code);
            Assert.AreEqual(shippingRate.Price, Nuvango.ShippingRate.Test.Price);
        }
    }
}
