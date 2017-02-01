using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialCommunity.ECommerce.Services.Services
{
    public class FulfillmentServiceFactory : Service, IFulfillmentServiceFactory
    {
        public async Task<IFulfillmentService> GetService(Dictionary<string, string> configuration)
        {
            return null;
        }
    }
}
