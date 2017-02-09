using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OfficialCommunity.ECommerce.Nop.Domains.Business;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Nop.Services
{
    public partial class NopService
    {
        public class Factory : ServiceFactory, IStoreServiceFactory
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

            public async Task<IStandardResponse<IStoreService>> GetInstance(string passport
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
                        var configuration = JsonConvert.DeserializeObject<Configuration>(JsonConvert.SerializeObject(properties));

                        var optionsBuilder = new DbContextOptionsBuilder<NopCommerceDbContext>();

                        optionsBuilder.UseSqlServer(configuration.ConnectionString);

                        var logger = _serviceProvider.GetService<ILogger<NopService>>();

                        IStoreService service = new NopService(logger, new NopCommerceDbContext(optionsBuilder.Options));

                        return service.GenerateStandardResponse();
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e, nameof(GetInstance));
                        return default(IStoreService).GenerateStandardError(nameof(GetInstance));
                    }
                }
            }
        }
    }
}
