using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Services;

namespace OfficialCommunity.ECommerce.Isotope.Services
{
    public partial class IsotopeService : Service, IFulfillmentService
    {
        private static readonly IEnumerable<string> _configurationProperties;

        static IsotopeService()
        {
            // todo: update session properties
            _configurationProperties = new List<string>();


        }

        private const string _name = "isotope";
        private static readonly Guid _key = new Guid("13240A4C-B6F4-4721-AC88-E1C9E8DEE60B");

        private readonly ILogger<IsotopeService> _logger;

        public IsotopeService(ILogger<IsotopeService> logger)
            : base(_name, _key)
        {
            _logger = logger;
        }

        public IFufillmentCatalogService Catalog => this;
        public IFufillmentOrdersService Orders => this;
        public IFufillmentShippingService Shipping => this;
        public override IEnumerable<string> ConfigurationProperties()
        {
            return _configurationProperties;
        }
    }
}
