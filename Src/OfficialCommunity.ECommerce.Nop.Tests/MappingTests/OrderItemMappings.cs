using ExpressMapper;
using NUnit.Framework;
using OfficialCommunity.ECommerce.Nop.Domains.Business;
using Common = OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Nop.Tests.MappingTests
{
    [TestFixture]
    public class OrderItemMappings : MappingsBase
    {
        [Test]
        public void when_nop_orderitem_with_shipping_status_shipping_not_required_is_mapped_to_common_orderitem()
        {
            var source = TestData.Nop.OrderItemShippingStatusShippingNotRequired;

            var orderItem = Mapper.Map<OrderItem, Common.OrderItem>(source);

            Assert.AreEqual(orderItem.Id, source.Id.ToString());
            Assert.AreEqual(orderItem.Name, source.Product.Name);
            Assert.AreEqual(orderItem.Quantity, source.Quantity);
            Assert.AreEqual(orderItem.Sku, source.Product.FulfillmentPartnerSku);
            Assert.AreEqual(orderItem.UnitPrice, source.Product.Price);
            Assert.AreEqual(orderItem.ShippingState, Common.ShippingState.Error);
        }

        [Test]
        public void when_nop_orderitem_with_shipping_status_not_yet_shipped_is_mapped_to_common_orderitem()
        {
            var source = TestData.Nop.OrderItemShippingStatusNotYetShipped;

            var orderItem = Mapper.Map<OrderItem, Common.OrderItem>(source);

            Assert.AreEqual(orderItem.Id, source.Id.ToString());
            Assert.AreEqual(orderItem.Name, source.Product.Name);
            Assert.AreEqual(orderItem.Quantity, source.Quantity);
            Assert.AreEqual(orderItem.Sku, source.Product.FulfillmentPartnerSku);
            Assert.AreEqual(orderItem.UnitPrice, source.Product.Price);
            Assert.AreEqual(orderItem.ShippingState, Common.ShippingState.NotYetShipped);
        }

        [Test]
        public void when_nop_orderitem_with_shipping_status_partially_shipped_is_mapped_to_common_orderitem()
        {
            var source = TestData.Nop.OrderItemShippingStatusPartiallyShipped;

            var orderItem = Mapper.Map<OrderItem, Common.OrderItem>(source);

            Assert.AreEqual(orderItem.Id, source.Id.ToString());
            Assert.AreEqual(orderItem.Name, source.Product.Name);
            Assert.AreEqual(orderItem.Quantity, source.Quantity);
            Assert.AreEqual(orderItem.Sku, source.Product.FulfillmentPartnerSku);
            Assert.AreEqual(orderItem.UnitPrice, source.Product.Price);
            Assert.AreEqual(orderItem.ShippingState, Common.ShippingState.PartiallyShipped);
        }

        [Test]
        public void when_nop_orderitem_with_shipping_status_shipped_is_mapped_to_common_orderitem()
        {
            var source = TestData.Nop.OrderItemShippingStatusShipped;

            var orderItem = Mapper.Map<OrderItem, Common.OrderItem>(source);

            Assert.AreEqual(orderItem.Id, source.Id.ToString());
            Assert.AreEqual(orderItem.Name, source.Product.Name);
            Assert.AreEqual(orderItem.Quantity, source.Quantity);
            Assert.AreEqual(orderItem.Sku, source.Product.FulfillmentPartnerSku);
            Assert.AreEqual(orderItem.UnitPrice, source.Product.Price);
            Assert.AreEqual(orderItem.ShippingState, Common.ShippingState.Shipped);
        }

        [Test]
        public void when_nop_orderitem_with_shipping_status_delivered_is_mapped_to_common_orderitem()
        {
            var source = TestData.Nop.OrderItemShippingStatusDelivered;

            var orderItem = Mapper.Map<OrderItem, Common.OrderItem>(source);

            Assert.AreEqual(orderItem.Id, source.Id.ToString());
            Assert.AreEqual(orderItem.Name, source.Product.Name);
            Assert.AreEqual(orderItem.Quantity, source.Quantity);
            Assert.AreEqual(orderItem.Sku, source.Product.FulfillmentPartnerSku);
            Assert.AreEqual(orderItem.UnitPrice, source.Product.Price);
            Assert.AreEqual(orderItem.ShippingState, Common.ShippingState.Shipped);
        }

        [Test]
        public void when_nop_orderitem_with_shipping_status_unknown_is_mapped_to_common_orderitem()
        {
            var source = TestData.Nop.OrderItemShippingStatusUnknown;

            var orderItem = Mapper.Map<OrderItem, Common.OrderItem>(source);

            Assert.AreEqual(orderItem.Id, source.Id.ToString());
            Assert.AreEqual(orderItem.Name, source.Product.Name);
            Assert.AreEqual(orderItem.Quantity, source.Quantity);
            Assert.AreEqual(orderItem.Sku, source.Product.FulfillmentPartnerSku);
            Assert.AreEqual(orderItem.UnitPrice, source.Product.Price);
            Assert.AreEqual(orderItem.ShippingState, Common.ShippingState.Unknown);
        }
    }
}
