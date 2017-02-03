using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Nuvango.Infrastructure;
using OfficialCommunity.ECommerce.Services;

namespace OfficialCommunity.ECommerce.Nuvango.Services
{
    public partial class NuvangoService : Service, IFulfillmentService
    {
        private static readonly IEnumerable<string> _configurationProperties;

        static NuvangoService()
        {
            _configurationProperties = typeof(NuvangoConfiguration)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Select(prop => prop.Name)
                .ToList();
        }

        public override IEnumerable<string> ConfigurationProperties()
        {
            return _configurationProperties;
        }

        //---------------------------------------

        private const string _name = "nuvango";
        private static readonly Guid _key = new Guid("702C1976-D0E2-4A60-96D5-D6A8EB9ACE63");

        private readonly ILogger<NuvangoService> _logger;
        private readonly ISession _session;

        public NuvangoService(ILogger<NuvangoService> logger, ISession session)
            : base(_name,_key)
        {
            _logger = logger;
            _session = session;
        }

        public IFufillmentCatalogService Catalog => this;
        public IFufillmentOrdersService Orders => this;
        public IFufillmentShippingService Shipping => this;
    }
}