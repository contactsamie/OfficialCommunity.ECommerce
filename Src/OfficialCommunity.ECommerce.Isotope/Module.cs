using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Isotope.Services;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace OfficialCommunity.ECommerce.Isotope
{
    public class Module : IModule
    {
        public void RegisterMappings()
        {
        }

        public void ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
        }

        public void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IFufillmentServiceFactory, IsotopeService.Factory>();
        }

        public void Configure(IConfiguration configuration, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
        }
    }
}
