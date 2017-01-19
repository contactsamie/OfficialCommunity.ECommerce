using ExpressMapper;
using NUnit.Framework;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class BasketLineMappings : MappingsBase
    {
        [Test]
        public void when_common_basketline_is_mapped_to_nuvango_orderitem()
        {
            var orderItem =
                Mapper.Map<ECommerce.Domains.Business.BasketLine, Domains.Business.OrderItem>(Common.BasketLine.Test);

            Assert.AreEqual(orderItem.Id, int.Parse(Common.BasketLine.Test.Sku));
            Assert.AreEqual(orderItem.Quantity, Common.BasketLine.Test.Quantity);
        }
    }
}
