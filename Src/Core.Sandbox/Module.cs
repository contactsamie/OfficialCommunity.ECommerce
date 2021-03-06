using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Nuvango.Services;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.ECommerce.Services.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Core.Sandbox
{
    public class Module : IModule
    {
        public void RegisterMappings()
        {
        }

        public void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IStoreTokenService, StoreTokenService>();
            
            //serviceCollection.Configure<NuvangoConfiguration>(configuration.GetSection("NuvangoConfiguration"));
            serviceCollection.AddTransient<IFulfillmentService, NuvangoService>();

            serviceCollection.Configure<LockService.LockServiceConfiguration>(configuration.GetSection("LockServiceConfiguration"));
            serviceCollection.AddTransient<ILockService, LockService>();

            serviceCollection.Configure<CatalogEntityService.CatalogServiceConfiguration>(configuration.GetSection("DefaultAzureStorageTableConfiguration"));
            serviceCollection.AddTransient<ICatalogEntityService, CatalogEntityService>();

            serviceCollection.Configure<StoreEntityService.StoreServiceConfiguration>(configuration.GetSection("DefaultAzureStorageTableConfiguration"));
            serviceCollection.AddTransient<IStoreEntityService, StoreEntityService>();
        }

        public void ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
            ConfigureIfDebug(configurationBuilder);
        }

        public void Configure(IConfiguration configuration, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(configuration.GetSection("Logging"));
        }

        [Conditional("DEBUG")]
        private static void ConfigureIfDebug(IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddUserSecrets<Program>();
        }
    }
}
