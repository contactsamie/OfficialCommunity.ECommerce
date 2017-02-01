using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Services;

namespace OfficialCommunity.ECommerce.Isotope.Services
{
    public partial class IsotopeService : Service, IFulfillmentService
    {
        private const string _name = "isotope";
        private static readonly Guid _key = new Guid("13240A4C-B6F4-4721-AC88-E1C9E8DEE60B");

        private readonly ILogger<IsotopeService> _logger;

        public IsotopeService(ILogger<IsotopeService> logger)
            : base(_name, _key)
        {
            _logger = logger;
        }

        public ICatalogService Catalog => this;
        public IOrdersService Orders => this;
        public IShippingService Shipping => this;
    }
}
