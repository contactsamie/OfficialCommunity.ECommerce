using ExpressMapper;
using NUnit.Framework;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class ProductMappings : MappingsBase
    {
        [Test]
        public void when_nuvango_product_is_mapped_to_common_product()
        {
            var product =
                Mapper.Map<Domains.Business.Product, ECommerce.Domains.Business.Product>(Nuvango.Product.Test);

            Assert.AreEqual(product.Id, Nuvango.Product.Test.Id.ToString());
            Assert.AreEqual(product.Name, Nuvango.Product.Test.Name);

            Assert.AreEqual(product.Options.Count, 2);
            var sourceIndex = 0;
            foreach (var option in product.Options)
            {
                var source = Nuvango.Product.Test.Options[sourceIndex];
                Assert.AreEqual(option.Name, source.Name);
                Assert.AreEqual(option.Values, source.Values);
                sourceIndex++;
            }

            Assert.AreEqual(product.Variants.Count, 3);
            sourceIndex = 0;
            foreach (var variant in product.Variants)
            {
                var source = Nuvango.Product.Test.Variants[sourceIndex];

                Assert.AreEqual(variant.Options.Count, 2);
                var variantIndex = 0;
                foreach (var option in variant.Options)
                {
                    var variantSource = source.Options[variantIndex];
                    Assert.AreEqual(option.Name, variantSource.Name);
                    Assert.AreEqual(option.Values, variantSource.Values);
                    variantIndex++;
                }
                sourceIndex++;
            }
        }
    }
}
