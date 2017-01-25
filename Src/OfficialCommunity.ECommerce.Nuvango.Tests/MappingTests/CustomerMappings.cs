using ExpressMapper;
using NUnit.Framework;
using Common = OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class CustomerMappings : MappingsBase
    {
        [Test]
        public void when_common_customer_is_mapped_to_nuvango_address()
        {
            var address = new Domains.Business.Address();

            Mapper.Map(TestData.Customer.Test, address);

            Assert.AreEqual(address.Phone, TestData.Customer.Test.Phone);
        }

        [Test]
        public void when_common_customer_is_mapped_to_nuvango_customer()
        {
            var customer =
                Mapper.Map<Common.Customer, Domains.Business.Customer>(TestData.Customer.Test);

            Assert.AreEqual(customer.FirstName, TestData.Customer.Test.FirstName);
            Assert.AreEqual(customer.LastName, TestData.Customer.Test.LastName);
            Assert.AreEqual(customer.EMail, TestData.Customer.Test.EMail);
        }

        [Test]
        public void when_nuvango_address_is_mapped_to_common_customer()
        {
            var customer = 
                Mapper.Map<Domains.Business.Address, Common.Customer>(Nuvango.Address.Test);

            Assert.AreEqual(customer.FirstName, Nuvango.Address.Test.FirstName);
            Assert.AreEqual(customer.LastName, Nuvango.Address.Test.LastName);
            Assert.AreEqual(customer.Phone, Nuvango.Address.Test.Phone);
        }
    }
}