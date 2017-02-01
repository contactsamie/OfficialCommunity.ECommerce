using System;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Nuvango.Infrastructure;
using OfficialCommunity.ECommerce.Services;

namespace OfficialCommunity.ECommerce.Nuvango.Services
{
    public partial class NuvangoService : Service, IFulfillmentService
    {
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

        public ICatalogService Catalog => this;
        public IOrdersService Orders => this;
        public IShippingService Shipping => this;
    }
}