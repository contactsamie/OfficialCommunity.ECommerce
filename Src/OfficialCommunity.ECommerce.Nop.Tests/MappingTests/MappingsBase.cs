using ExpressMapper;
using NUnit.Framework;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Nop.Tests.MappingTests
{
    [TestFixture]
    public class MappingsBase
    {
        private IModule _module;

        [SetUp]
        public void Setup()
        {
            _module = new Module();
            _module.RegisterMappings();
            Mapper.Compile();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
