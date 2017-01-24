using ExpressMapper;
using NUnit.Framework;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class AddressMappings : MappingsBase
    {
        [Test]
        public void when_common_address_is_mapped_to_nuvango_address()
        {
            var address =
                Mapper.Map<ECommerce.Domains.Business.Address, Domains.Business.Address>(Common.Address.Test);

            Assert.AreEqual(address.FirstName, Common.Address.Test.FirstName);
            Assert.AreEqual(address.LastName, Common.Address.Test.LastName);
            Assert.AreEqual(address.Company, Common.Address.Test.Company);
            Assert.AreEqual(address.Address1, Common.Address.Test.Address1);
            Assert.AreEqual(address.Address2, Common.Address.Test.Address2);
            Assert.AreEqual(address.City, Common.Address.Test.City);
            Assert.AreEqual(address.Region, Common.Address.Test.Region);
            Assert.AreEqual(address.Country, Common.Address.Test.Country);
            Assert.AreEqual(address.Zip, Common.Address.Test.Zip);
        }

        [Test]
        public void when_nuvango_address_is_mapped_to_common_address()
        {
            var address =
                Mapper.Map<Domains.Business.Address, ECommerce.Domains.Business.Address>(Nuvango.Address.Test);

            Assert.AreEqual(address.FirstName, Nuvango.Address.Test.FirstName);
            Assert.AreEqual(address.LastName, Nuvango.Address.Test.LastName);
            Assert.AreEqual(address.Company, Nuvango.Address.Test.Company);
            Assert.AreEqual(address.Address1, Nuvango.Address.Test.Address1);
            Assert.AreEqual(address.Address2, Nuvango.Address.Test.Address2);
            Assert.AreEqual(address.City, Nuvango.Address.Test.City);
            Assert.AreEqual(address.Region, Nuvango.Address.Test.Region);
            Assert.AreEqual(address.Country, Nuvango.Address.Test.Country);
            Assert.AreEqual(address.Zip, Nuvango.Address.Test.Zip);
        }
    }
}