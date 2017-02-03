using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.ECommerce.Services.Domains.Services;

namespace OfficialCommunity.ECommerce.Services.Services
{
    public class StoreEntityService : TableEntityService<StoreTableEntity, StoreEntityService.StoreServiceConfiguration>
        , IStoreEntityService
    {
        public class StoreServiceConfiguration : Configuration
        {
        }

        public StoreEntityService(ILogger<StoreEntityService> logger
            , IOptions<StoreServiceConfiguration> configuration)
            : base(logger, configuration)
        {
        }
    }
}