using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace OfficialCommunity.Necropolis.DocumentDB
{
    public class Module : IModule
    {
        public void RegisterMappings()
        {
        }

        public void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
        {
        }

        public void ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
        }

        public void Configure(IConfiguration configuration, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
        }
    }
}
