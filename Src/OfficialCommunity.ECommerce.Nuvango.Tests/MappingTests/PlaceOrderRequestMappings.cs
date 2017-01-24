using ExpressMapper;
using NUnit.Framework;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class PlaceOrderRequestMappings : MappingsBase
    {
        [Test]
        public void when_common_order_is_mapped_to_nuvango_placeorderrequest()
        {
            var request =
                Mapper.Map<ECommerce.Domains.Business.Order, Domains.Messages.PlaceOrderRequest>(Common.Order.Test);

            Assert.AreEqual(request.OrderNumber, Common.Order.Test.Id);
            Assert.AreEqual(request.TimeStampUtc, Common.Order.Test.TimeStampUtc);
            Assert.AreEqual(request.Tax, Common.Order.Test.Tax);
            Assert.AreEqual(request.SubtotalPrice, Common.Order.Test.SubtotalPrice);
            Assert.AreEqual(request.Discounts, Common.Order.Test.Discounts);
            Assert.AreEqual(request.TotalPrice, Common.Order.Test.TotalPrice);

            var sourceIndex = 0;
            foreach (var item in request.OrderItems)
            {
                var source = Common.Order.Test.OrderItems[sourceIndex];
                Assert.AreEqual(item.Id, int.Parse(source.Id));
                Assert.AreEqual(item.Quantity, source.Quantity);
                Assert.AreEqual(item.UnitPrice, source.UnitPrice);
                sourceIndex++;
            }
        }

        [Test]
        public void when_common_customer_is_mapped_to_nuvango_placeorderrequest_customer()
        {
            var request =
                Mapper.Map<ECommerce.Domains.Business.Order, Domains.Messages.PlaceOrderRequest>(Common.Order.Test);
            request.Customer = Mapper.Map<ECommerce.Domains.Business.Customer, Domains.Business.Customer>(Common.Customer.Test);

            Assert.AreEqual(request.Customer.FirstName, Common.Customer.Test.FirstName);
            Assert.AreEqual(request.Customer.LastName, Common.Customer.Test.LastName);
            Assert.AreEqual(request.Customer.EMail, Common.Customer.Test.EMail);
        }

        [Test]
        public void when_common_address_is_mapped_to_nuvango_placeorderrequest_address()
        {
            var request =
                Mapper.Map<ECommerce.Domains.Business.Order, Domains.Messages.PlaceOrderRequest>(Common.Order.Test);
            request.Address = Mapper.Map<ECommerce.Domains.Business.Address, Domains.Business.Address>(Common.Address.Test);

            Assert.AreEqual(request.Address.FirstName, Common.Address.Test.FirstName);
            Assert.AreEqual(request.Address.LastName, Common.Address.Test.LastName);
            Assert.AreEqual(request.Address.Company, Common.Address.Test.Company);
            Assert.AreEqual(request.Address.Address1, Common.Address.Test.Address1);
            Assert.AreEqual(request.Address.Address2, Common.Address.Test.Address2);
            Assert.AreEqual(request.Address.City, Common.Address.Test.City);
            Assert.AreEqual(request.Address.Region, Common.Address.Test.Region);
            Assert.AreEqual(request.Address.Country, Common.Address.Test.Country);
            Assert.AreEqual(request.Address.Zip, Common.Address.Test.Zip);
        }

        [Test]
        public void when_common_customer_is_mapped_to_nuvango_placeorderrequest_address()
        {
            var request =
                Mapper.Map<ECommerce.Domains.Business.Order, Domains.Messages.PlaceOrderRequest>(Common.Order.Test);
            request.Address = Mapper.Map<ECommerce.Domains.Business.Address, Domains.Business.Address>(Common.Address.Test);

            Mapper.Map(Common.Customer.Test, request.Address);

            Assert.AreEqual(request.Address.Phone, Common.Customer.Test.Phone);
        }

        [Test]
        public void when_common_shippingrate_is_mapped_to_nuvango_placeorderrequest_shippingrate()
        {
            var request =
                Mapper.Map<ECommerce.Domains.Business.Order, Domains.Messages.PlaceOrderRequest>(Common.Order.Test);
            request.ShippingRate = Mapper.Map<ECommerce.Domains.Business.ShippingRate, Domains.Business.ShippingRate>(Common.ShippingRate.Test);

            Assert.AreEqual(request.ShippingRate.Carrier, Common.ShippingRate.Test.Carrier);
            Assert.AreEqual(request.ShippingRate.Title, Common.ShippingRate.Test.Title);
            Assert.AreEqual(request.ShippingRate.Code, Common.ShippingRate.Test.Code);
            Assert.AreEqual(request.ShippingRate.Price, Common.ShippingRate.Test.Price);
        }
    }
}
