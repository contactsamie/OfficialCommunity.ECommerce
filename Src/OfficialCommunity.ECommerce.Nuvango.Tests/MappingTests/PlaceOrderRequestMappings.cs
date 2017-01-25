using ExpressMapper;
using Newtonsoft.Json;
using NUnit.Framework;
using Common = OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class PlaceOrderRequestMappings : MappingsBase
    {
        [Test]
        public void when_common_order_is_mapped_to_nuvango_placeorderrequest()
        {
            var request =
                Mapper.Map<Common.Order, Domains.Messages.PlaceOrderRequest>(TestData.Order.Test);

            Assert.AreEqual(request.OrderNumber, TestData.Order.Test.Id);
            Assert.AreEqual(request.TimeStampUtc, TestData.Order.Test.TimeStampUtc);
            Assert.AreEqual(request.Tax, TestData.Order.Test.Tax);
            Assert.AreEqual(request.SubtotalPrice, TestData.Order.Test.SubtotalPrice);
            Assert.AreEqual(request.Discounts, TestData.Order.Test.Discounts);
            Assert.AreEqual(request.TotalPrice, TestData.Order.Test.TotalPrice);

            var sourceIndex = 0;
            foreach (var item in request.OrderItems)
            {
                var source = TestData.Order.Test.OrderItems[sourceIndex];
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
                Mapper.Map<Common.Order, Domains.Messages.PlaceOrderRequest>(TestData.Order.Test);
            request.Customer = Mapper.Map<Common.Customer, Domains.Business.Customer>(TestData.Customer.Test);

            Assert.AreEqual(request.Customer.FirstName, TestData.Customer.Test.FirstName);
            Assert.AreEqual(request.Customer.LastName, TestData.Customer.Test.LastName);
            Assert.AreEqual(request.Customer.EMail, TestData.Customer.Test.EMail);
        }

        [Test]
        public void when_common_address_is_mapped_to_nuvango_placeorderrequest_address()
        {
            var request =
                Mapper.Map<Common.Order, Domains.Messages.PlaceOrderRequest>(TestData.Order.Test);
            request.Address = Mapper.Map<Common.Address, Domains.Business.Address>(TestData.Address.Test);

            Assert.AreEqual(request.Address.FirstName, TestData.Address.Test.FirstName);
            Assert.AreEqual(request.Address.LastName, TestData.Address.Test.LastName);
            Assert.AreEqual(request.Address.Company, TestData.Address.Test.Company);
            Assert.AreEqual(request.Address.Address1, TestData.Address.Test.Address1);
            Assert.AreEqual(request.Address.Address2, TestData.Address.Test.Address2);
            Assert.AreEqual(request.Address.City, TestData.Address.Test.City);
            Assert.AreEqual(request.Address.RegionCode, TestData.Address.Test.RegionCode);
            Assert.AreEqual(request.Address.CountryCode, TestData.Address.Test.CountryCode);
            Assert.AreEqual(request.Address.Zip, TestData.Address.Test.Zip);
        }

        [Test]
        public void when_common_customer_is_mapped_to_nuvango_placeorderrequest_address()
        {
            var request =
                Mapper.Map<Common.Order, Domains.Messages.PlaceOrderRequest>(TestData.Order.Test);
            request.Address = Mapper.Map<Common.Address, Domains.Business.Address>(TestData.Address.Test);

            Mapper.Map(TestData.Customer.Test, request.Address);

            Assert.AreEqual(request.Address.Phone, TestData.Customer.Test.Phone);
        }

        [Test]
        public void when_common_shippingrate_is_mapped_to_nuvango_placeorderrequest_shippingrate()
        {
            var request =
                Mapper.Map<Common.Order, Domains.Messages.PlaceOrderRequest>(TestData.Order.Test);

            request.ShippingRate = Mapper.Map<Common.ShippingRate, Domains.Business.ShippingRate>(TestData.ShippingRate.Test);

            var deserializedShippingRate =
                JsonConvert.DeserializeObject<Domains.Business.ShippingRate>(TestData.ShippingRate.Test.Json);

            Assert.AreEqual(request.ShippingRate.Carrier, deserializedShippingRate.Carrier);
            Assert.AreEqual(request.ShippingRate.Title, deserializedShippingRate.Title);
            Assert.AreEqual(request.ShippingRate.Code, deserializedShippingRate.Code);
            Assert.AreEqual(request.ShippingRate.Price, deserializedShippingRate.Price);
            Assert.AreEqual(request.ShippingRate.Currency, deserializedShippingRate.Currency);
        }
    }
}
