using ExpressMapper;
using NUnit.Framework;
using Common = OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class CartItemMappings : MappingsBase
    {
        [Test]
        public void when_common_basketline_is_mapped_to_nuvango_orderitem()
        {
            var orderItem =
                Mapper.Map<Common.CartItem, Domains.Business.OrderItem>(TestData.CartItem.Test);

            Assert.AreEqual(orderItem.Id, int.Parse(TestData.CartItem.Test.Sku));
            Assert.AreEqual(orderItem.Quantity, TestData.CartItem.Test.Quantity);
        }
    }
}
