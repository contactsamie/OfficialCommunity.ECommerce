using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Isotope.Services
{
    public partial class IsotopeService
    {
        public class Factory : ServiceFactory<IFulfillmentService>, IFulfillmentServiceFactory
        {
            private static readonly IEnumerable<string> _configurationProperties;

            static Factory()
            {
                _configurationProperties = typeof(Configuration)
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(prop => prop.Name)
                    .ToList();
            }

            //---------------------------------------

            private readonly ILogger<Factory> _logger;
            private readonly IServiceProvider _serviceProvider;

            public Factory(ILogger<Factory> logger
                                , IServiceProvider serviceProvider)
                : base(_name, _key)
            {
                _logger = logger;
                _serviceProvider = serviceProvider;
            }

            public override IEnumerable<string> ConfigurationProperties()
            {
                return _configurationProperties;
            }

            public override async Task<IStandardResponse<IFulfillmentService>> GetInstance(string passport
                        , Dictionary<string, string> properties
            )
            {
                var entry = EntryContext.Capture
                                            .Passport(passport)
                                            .Name(nameof(GetInstance))
                                            .EntryContext
                                        ;

                using (_logger.BeginScope(entry))
                {
                    try
                    {
                        var logger = _serviceProvider.GetService<ILogger<IsotopeService>>();

                        IFulfillmentService service = new IsotopeService(logger);

                        return service.GenerateStandardResponse();
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e, nameof(GetInstance));
                        return default(IFulfillmentService).GenerateStandardError(nameof(GetInstance));
                    }
                }
            }
        }
    }
}
