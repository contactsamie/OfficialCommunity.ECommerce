using ExpressMapper;
using NUnit.Framework;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class ProductVariantMappings : MappingsBase
    {
        [Test]
        public void when_nuvango_productvariant_is_mapped_to_common_productvariant()
        {
            var productVariant =
                Mapper.Map<Domains.Business.ProductVariant, ECommerce.Domains.Business.ProductVariant>(Nuvango.ProductVariant.Test);


            Assert.AreEqual(productVariant.Id, Nuvango.ProductVariant.Test.Id.ToString());
            Assert.AreEqual(productVariant.Options.Count, 2);

            var sourceIndex = 0;
            foreach (var option in productVariant.Options)
            {
                var source = Nuvango.ProductVariant.Test.Options[sourceIndex];
                Assert.AreEqual(option.Name, source.Name);
                Assert.AreEqual(option.Values, source.Values);
                sourceIndex++;
            }
        }
    }
}
