using ExpressMapper;
using NUnit.Framework;
using OfficialCommunity.ECommerce.Nop.Domains.Business;
using Common = OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Nop.Tests.MappingTests
{
    [TestFixture]
    public class CustomerMappings : MappingsBase
    {
        [Test]
        public void when_nop_customer_is_mapped_to_common_customer()
        {
            var customer =
                Mapper.Map<Customer, Common.Customer>(TestData.Nop.Customer);

            Assert.AreEqual(customer.FirstName, TestData.Nop.Customer.ShippingAddress.FirstName);
            Assert.AreEqual(customer.LastName, TestData.Nop.Customer.ShippingAddress.LastName);
            Assert.AreEqual(customer.EMail, TestData.Nop.Customer.ShippingAddress.Email);
            Assert.AreEqual(customer.Phone, TestData.Nop.Customer.ShippingAddress.PhoneNumber);
        }
    }
}
