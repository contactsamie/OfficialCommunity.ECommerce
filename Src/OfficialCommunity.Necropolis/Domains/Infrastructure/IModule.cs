using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OfficialCommunity.Necropolis.Domains.Infrastructure
{
    public interface IModule
    {
        void RegisterMappings();
        void ConfigureConfiguration(IConfigurationBuilder configurationBuilder);
        void ConfigureServices(Microsoft.Extensions.Configuration.IConfiguration configuration, IServiceCollection serviceCollection);
        void Configure(Microsoft.Extensions.Configuration.IConfiguration configuration
                        , IServiceProvider serviceProvider
                        , ILoggerFactory loggerFactory);
    }
}
