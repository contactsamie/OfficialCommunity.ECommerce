using ExpressMapper;
using NUnit.Framework;
using OfficialCommunity.ECommerce.Nop.Domains.Business;
using Common = OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Nop.Tests.MappingTests
{
    [TestFixture]
    public class AddressMappings : MappingsBase
    {
        [Test]
        public void when_nop_address_with_region_is_mapped_to_common_address()
        {
            var address =
                Mapper.Map<Address, Common.Address>(TestData.Nop.AddressWithRegion);

            Assert.AreEqual(address.FirstName, TestData.Nop.AddressWithRegion.FirstName);
            Assert.AreEqual(address.LastName, TestData.Nop.AddressWithRegion.LastName);
            Assert.AreEqual(address.Company, TestData.Nop.AddressWithRegion.Company);
            Assert.AreEqual(address.Address1, TestData.Nop.AddressWithRegion.Address1);
            Assert.AreEqual(address.Address2, TestData.Nop.AddressWithRegion.Address2);
            Assert.AreEqual(address.City, TestData.Nop.AddressWithRegion.City);
            Assert.AreEqual(address.RegionCode, TestData.Nop.AddressWithRegion.StateProvince.Abbreviation);
            Assert.AreEqual(address.CountryCode, TestData.Nop.AddressWithRegion.Country.ThreeLetterIsoCode);
            Assert.AreEqual(address.Zip, TestData.Nop.AddressWithRegion.ZipPostalCode);
        }

        [Test]
        public void when_nop_address_without_region_is_mapped_to_common_address()
        {
            var address =
                Mapper.Map<Address, Common.Address>(TestData.Nop.AddressWithoutRegion);

            Assert.AreEqual(address.FirstName, TestData.Nop.AddressWithoutRegion.FirstName);
            Assert.AreEqual(address.LastName, TestData.Nop.AddressWithoutRegion.LastName);
            Assert.AreEqual(address.Company, TestData.Nop.AddressWithoutRegion.Company);
            Assert.AreEqual(address.Address1, TestData.Nop.AddressWithoutRegion.Address1);
            Assert.AreEqual(address.Address2, TestData.Nop.AddressWithoutRegion.Address2);
            Assert.AreEqual(address.City, TestData.Nop.AddressWithoutRegion.City);
            Assert.IsNull(address.RegionCode);
            Assert.AreEqual(address.CountryCode, TestData.Nop.AddressWithoutRegion.Country.ThreeLetterIsoCode);
            Assert.AreEqual(address.Zip, TestData.Nop.AddressWithoutRegion.ZipPostalCode);
        }
    }
}
