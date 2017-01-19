using ExpressMapper;
using NUnit.Framework;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class CustomerMappings : MappingsBase
    {
        [Test]
        public void when_common_customer_is_mapped_to_nuvango_address()
        {
            var address = new Domains.Business.Address();

            Mapper.Map(Common.Customer.Test, address);

            Assert.AreEqual(address.Phone, Common.Customer.Test.Phone);
        }

        [Test]
        public void when_nuvango_address_is_mapped_to_common_customer()
        {
            var customer = 
                Mapper.Map<Domains.Business.Address, ECommerce.Domains.Business.Customer>(Nuvango.Address.Test);

            Assert.AreEqual(customer.FirstName, Nuvango.Address.Test.FirstName);
            Assert.AreEqual(customer.LastName, Nuvango.Address.Test.LastName);
            Assert.AreEqual(customer.Phone, Nuvango.Address.Test.Phone);
        }
    }
}