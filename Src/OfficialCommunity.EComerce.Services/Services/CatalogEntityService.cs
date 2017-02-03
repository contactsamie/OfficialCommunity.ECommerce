using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.ECommerce.Services.Domains.Services;

namespace OfficialCommunity.ECommerce.Services.Services
{
    public class CatalogEntityService : TableEntityService<CatalogTableEntity, CatalogEntityService.CatalogServiceConfiguration>
                                        , ICatalogEntityService
    {
        public class CatalogServiceConfiguration : Configuration
        {
        }

        public CatalogEntityService(ILogger<CatalogEntityService> logger
                            , IOptions<CatalogServiceConfiguration> configuration)
            : base(logger, configuration)
        {
        }
    }
}
