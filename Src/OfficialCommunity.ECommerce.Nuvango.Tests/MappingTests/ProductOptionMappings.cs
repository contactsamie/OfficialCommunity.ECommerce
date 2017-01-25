using ExpressMapper;
using NUnit.Framework;
using Common = OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class ProductOptionMappings : MappingsBase
    {
        [Test]
        public void when_nuvango_productoption_is_mapped_to_common_productoption()
        {
            var productOption =
                Mapper.Map<Domains.Business.ProductOption, Common.ProductOption>(Nuvango.ProductOption.Test);

            Assert.AreEqual(productOption.Name, Nuvango.ProductOption.Test.Name);
            Assert.AreEqual(productOption.Values, Nuvango.ProductOption.Test.Values);
        }
    }
}
