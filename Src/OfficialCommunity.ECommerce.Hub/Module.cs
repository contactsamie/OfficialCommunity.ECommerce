using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Hub.Data;
using OfficialCommunity.ECommerce.Hub.Domains.Editable;
using OfficialCommunity.ECommerce.Hub.Domains.Services;
using OfficialCommunity.ECommerce.Hub.Domains.Viewable;
using OfficialCommunity.ECommerce.Hub.Infrastructure;
using OfficialCommunity.ECommerce.Hub.Services;
using OfficialCommunity.ECommerce.Isotope.Services;
using OfficialCommunity.ECommerce.Nuvango;
using OfficialCommunity.ECommerce.Nuvango.Services;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.ECommerce.Services.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Domains.Services;
using OfficialCommunity.Necropolis.Services;
using Common = OfficialCommunity.ECommerce.Domains.Business;
using CommonService = OfficialCommunity.ECommerce.Services.Domains.Commands;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace OfficialCommunity.ECommerce.Hub
{
    public class Module : IModule
    {
        public static List<EditableConfiguration> MapConfiguration(Dictionary<string, string> configuration)
        {
            return configuration.Select(kvp => 
                                            new EditableConfiguration
                                            {
                                                Key = kvp.Key,
                                                Value = kvp.Value
                                            })
                                .ToList();
        }

        public static Dictionary<string, string> MapConfiguration(List<EditableConfiguration> configuration)
        {
            return configuration.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        public void RegisterMappings()
        {
            Mapper.Register<Common.Customer, ViewableCustomer>();
            Mapper.Register<Common.Address, ViewableAddress>();
            Mapper.Register<Common.ShippingRate, ViewableShippingRate>();
            Mapper.Register<Common.OrderItem, ViewableOrderItem>();
            Mapper.Register<Common.Order, ViewableOrder>()
                .Member(dest => dest.Customer, src => src.Customer)
                .Member(dest => dest.ShippingAddress, src => src.ShippingAddress)
                .Member(dest => dest.ShippingRate, src => src.ShippingRate)
                .Member(dest => dest.OrderItems, src => src.OrderItems)
                ;
            Mapper.Register<Common.Product, ViewableProduct>()
                .Ignore(dest => dest.Variants)
                ;

            Mapper.Register<CommonService.GetEntityCountResponse, ViewableProductCount>();

            Mapper.Register<CatalogTableEntity, EditableCatalogTableEntity>()
                .Function(dest => dest.ProviderConfiguration, src => MapConfiguration(src.ProviderConfiguration))
                ;
            Mapper.Register<EditableCatalogTableEntity, CatalogTableEntity>()
                .Function(dest => dest.ProviderConfiguration, src => MapConfiguration(src.ProviderConfiguration))
                ;

            Mapper.Register<Domains.Infrastructure.Log, ViewableLog>();
            Mapper.Register<Domains.Infrastructure.Operation, ViewableOperation>();
        }

        public void ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
        }

        public void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.AddDistributedRedisCache(option =>
            {
                option.Configuration = configuration.GetConnectionString("RedisConnection");
                option.InstanceName = configuration.GetConnectionString("RedisConnectionInstanceName");
            });

            serviceCollection.AddTransient<IOperationsService, OperationsService>();
            
            serviceCollection.AddTransient<IFulfillmentService, IsotopeService>();

            serviceCollection.Configure<NuvangoService.Configuration>(configuration.GetSection("NuvangoConfiguration"));
            serviceCollection.AddTransient<IFulfillmentService, NuvangoService>();

            serviceCollection.Configure<LockService.LockServiceConfiguration>(configuration.GetSection("LockServiceConfiguration"));
            serviceCollection.AddTransient<ILockService, LockService>();

            serviceCollection.Configure<CatalogEntityService.CatalogServiceConfiguration>(configuration.GetSection("DefaultAzureStorageTableConfiguration"));
            serviceCollection.AddTransient<ICatalogEntityService, CatalogEntityService>();

            serviceCollection.Configure<StoreEntityService.StoreServiceConfiguration>(configuration.GetSection("DefaultAzureStorageTableConfiguration"));
            serviceCollection.AddTransient<IStoreEntityService, StoreEntityService>();

            serviceCollection.AddTransient<ICacheManager, DistributedCacheManager>();
        }

        public void Configure(IConfiguration configuration, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
        }
    }
}
