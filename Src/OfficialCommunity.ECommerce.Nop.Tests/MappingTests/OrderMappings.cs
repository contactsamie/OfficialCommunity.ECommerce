using ExpressMapper;
using NUnit.Framework;
using OfficialCommunity.ECommerce.Nop.Domains.Business;
using Common = OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Nop.Tests.MappingTests
{
    [TestFixture]
    public class OrderMappings : MappingsBase
    {
        [Test]
        public void when_nop_order_is_mapped_to_common_store()
        {
            var source = TestData.Nop.Order;

            var store = Mapper.Map<Order, Common.Store>(source);

            Assert.AreEqual(store.Provider, Constants.Provider);
            Assert.AreEqual(store.Id, source.StoreId.ToString());
        }
        [Test]
        public void when_nop_order_is_mapped_to_common_order()
        {
            var source = TestData.Nop.Order;

            var order = Mapper.Map<Order, Common.Order>(source);

            Assert.AreEqual(order.Store.Provider, Constants.Provider);
            Assert.AreEqual(order.Store.Id, source.StoreId.ToString());
            Assert.AreEqual(order.Id, source.Id.ToString());
            Assert.AreEqual(order.TimeStampUtc, source.CreatedOnUtc);
            Assert.AreEqual(order.Currency, source.CustomerCurrencyCode);
            Assert.AreEqual(order.Tax, source.OrderTax);
            Assert.AreEqual(order.SubtotalPrice, source.OrderSubtotalInclTax);
            Assert.AreEqual(order.Discounts, source.OrderDiscount);
            Assert.AreEqual(order.TotalPrice, source.OrderTotal);

            Assert.AreEqual(order.Customer.FirstName, source.Customer.ShippingAddress.FirstName);
            Assert.AreEqual(order.Customer.LastName, source.Customer.ShippingAddress.LastName);
            Assert.AreEqual(order.Customer.EMail, source.Customer.ShippingAddress.Email);
            Assert.AreEqual(order.Customer.Phone, source.Customer.ShippingAddress.PhoneNumber);

            Assert.AreEqual(order.ShippingAddress.FirstName, source.ShippingAddress.FirstName);
            Assert.AreEqual(order.ShippingAddress.LastName, source.ShippingAddress.LastName);
            Assert.AreEqual(order.ShippingAddress.Company, source.ShippingAddress.Company);
            Assert.AreEqual(order.ShippingAddress.Address1, source.ShippingAddress.Address1);
            Assert.AreEqual(order.ShippingAddress.Address2, source.ShippingAddress.Address2);
            Assert.AreEqual(order.ShippingAddress.City, source.ShippingAddress.City);
            Assert.AreEqual(order.ShippingAddress.RegionCode, source.ShippingAddress.StateProvince.Abbreviation);
            Assert.AreEqual(order.ShippingAddress.CountryCode, source.ShippingAddress.Country.ThreeLetterIsoCode);
            Assert.AreEqual(order.ShippingAddress.Zip, source.ShippingAddress.ZipPostalCode);
        }
    }
}
