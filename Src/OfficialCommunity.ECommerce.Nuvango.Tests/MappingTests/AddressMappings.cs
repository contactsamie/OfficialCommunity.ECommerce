using ExpressMapper;
using NUnit.Framework;
using Common = OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Nuvango.Tests.MappingTests
{
    [TestFixture]
    public class AddressMappings : MappingsBase
    {
        [Test]
        public void when_common_address_is_mapped_to_nuvango_address()
        {
            var address =
                Mapper.Map<Common.Address, Domains.Business.Address>(TestData.Address.Test);

            Assert.AreEqual(address.FirstName, TestData.Address.Test.FirstName);
            Assert.AreEqual(address.LastName, TestData.Address.Test.LastName);
            Assert.AreEqual(address.Company, TestData.Address.Test.Company);
            Assert.AreEqual(address.Address1, TestData.Address.Test.Address1);
            Assert.AreEqual(address.Address2, TestData.Address.Test.Address2);
            Assert.AreEqual(address.City, TestData.Address.Test.City);
            Assert.AreEqual(address.RegionCode, TestData.Address.Test.RegionCode);
            Assert.AreEqual(address.CountryCode, TestData.Address.Test.CountryCode);
            Assert.AreEqual(address.Zip, TestData.Address.Test.Zip);
        }

        [Test]
        public void when_nuvango_address_is_mapped_to_common_address()
        {
            var address =
                Mapper.Map<Domains.Business.Address, Common.Address>(Nuvango.Address.Test);

            Assert.AreEqual(address.FirstName, Nuvango.Address.Test.FirstName);
            Assert.AreEqual(address.LastName, Nuvango.Address.Test.LastName);
            Assert.AreEqual(address.Company, Nuvango.Address.Test.Company);
            Assert.AreEqual(address.Address1, Nuvango.Address.Test.Address1);
            Assert.AreEqual(address.Address2, Nuvango.Address.Test.Address2);
            Assert.AreEqual(address.City, Nuvango.Address.Test.City);
            Assert.AreEqual(address.RegionCode, Nuvango.Address.Test.RegionCode);
            Assert.AreEqual(address.CountryCode, Nuvango.Address.Test.CountryCode);
            Assert.AreEqual(address.Zip, Nuvango.Address.Test.Zip);
        }
    }
}