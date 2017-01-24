using ExpressMapper;
using NUnit.Framework;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class CartItemMappings : MappingsBase
    {
        [Test]
        public void when_common_basketline_is_mapped_to_nuvango_orderitem()
        {
            var orderItem =
                Mapper.Map<ECommerce.Domains.Business.CartItem, Domains.Business.OrderItem>(Common.CartItem.Test);

            Assert.AreEqual(orderItem.Id, int.Parse(Common.CartItem.Test.Sku));
            Assert.AreEqual(orderItem.Quantity, Common.CartItem.Test.Quantity);
        }
    }
}
