using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Hub.Domains.Editable;
using OfficialCommunity.ECommerce.Hub.Domains.Services;
using OfficialCommunity.ECommerce.Hub.Domains.Viewable;
using OfficialCommunity.ECommerce.Hub.Services;
using OfficialCommunity.ECommerce.Isotope.Services;
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
        public static List<EditableStoreCatalog> MapStoreCatalog(Dictionary<Guid, string> configuration)
        {
            return configuration.Select(kvp => 
                                            new EditableStoreCatalog
                                            {
                                                Key = kvp.Key,
                                                Name = kvp.Value
                                            })
                                .ToList();
        }

        public static Dictionary<Guid, string> MapStoreCatalog(List<EditableStoreCatalog> configuration)
        {
            return configuration.ToDictionary(kvp => kvp.Key, kvp => kvp.Name);
        }

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

            Mapper.Register<StoreTableEntity, EditableStoreTableEntity>()
                .Function(dest => dest.ProviderConfiguration, src => MapConfiguration(src.ProviderConfiguration))
                .Function(dest => dest.Catalogs, src => MapStoreCatalog(src.Catalogs))
                ;

            Mapper.Register<EditableStoreTableEntity, StoreTableEntity>()
                .Function(dest => dest.ProviderConfiguration, src => MapConfiguration(src.ProviderConfiguration))
                .Function(dest => dest.Catalogs, src => MapStoreCatalog(src.Catalogs))
                ;

            Mapper.Register<CatalogTableEntity, EditableCatalogTableEntity>()
                .Function(dest => dest.ProviderConfiguration, src => MapConfiguration(src.ProviderConfiguration))
                /*
                .Ignore(dest => dest.ProviderConfiguration)
                .Member(d => d.PartitionKey, s => s.PartitionKey)
                .Member(d => d.RowKey, s => s.RowKey)
                .Member(d => d.Id, s => s.Id)
                .Member(d => d.Deleted, s => s.Deleted)
                .Member(d => d.Published, s => s.Published)
                .Member(d => d.CreatedUtc, s => s.CreatedUtc)
                .Member(d => d.CreatedBy, s => s.CreatedBy)
                .Member(d => d.LastUpdatedUtc, s => s.LastUpdatedUtc)
                .Member(d => d.LastUpdatedBy, s => s.LastUpdatedBy)
                .Member(d => d.Name, s => s.Description)
                .Member(d => d.ProviderName, s => s.ProviderName)
                .Member(d => d.ProviderKey, s => s.ProviderKey)
                /*
                .Member(d => d.PartitionKey, s => s.PartitionKey)
                .Member(d => d.RowKey, s => s.RowKey)
                .Member(d => d.Id, s => s.Id)
                .Member(d => d.Deleted, s => s.Deleted)
                .Member(d => d.Published, s => s.Published)
                .Member(d => d.CreatedUtc, s => s.CreatedUtc)
                .Member(d => d.CreatedBy, s => s.CreatedBy)
                .Member(d => d.LastUpdatedUtc, s => s.LastUpdatedUtc)
                .Member(d => d.LastUpdatedBy, s => s.LastUpdatedBy)
                .Member(d => d.Name, s => s.Description)
                .Member(d => d.ProviderName, s => s.ProviderName)
                .Member(d => d.ProviderKey, s => s.ProviderKey)
                */
                //.Ignore(d => d.PartitionKey)
                //.Ignore(d => d.RowKey)
                //.Ignore(d => d.Id)
                //.Ignore(d => d.Deleted)
                //.Ignore(d => d.Published)
                //.Ignore(d => d.CreatedUtc)
                //.Ignore(d => d.CreatedBy)
                //.Ignore(d => d.LastUpdatedUtc)
                //.Ignore(d => d.LastUpdatedBy)
                //.Ignore(d => d.Name)
                //.Ignore(d => d.ProviderName)
                //.Ignore(d => d.ProviderKey)
                ;

            Mapper.Register<EditableCatalogTableEntity, CatalogTableEntity>()
                .Function(dest => dest.ProviderConfiguration, src => MapConfiguration(src.ProviderConfiguration))
                /*
                .Ignore(dest => dest.ProviderConfiguration)
                .Member(d => d.PartitionKey, s => s.PartitionKey)
                .Member(d => d.RowKey, s => s.RowKey)
                .Member(d => d.Id, s => s.Id)
                .Member(d => d.Deleted, s => s.Deleted)
                .Member(d => d.Published, s => s.Published)
                .Member(d => d.CreatedUtc, s => s.CreatedUtc)
                .Member(d => d.CreatedBy, s => s.CreatedBy)
                .Member(d => d.LastUpdatedUtc, s => s.LastUpdatedUtc)
                .Member(d => d.LastUpdatedBy, s => s.LastUpdatedBy)
                .Member(d => d.Name, s => s.Description)
                .Member(d => d.ProviderName, s => s.ProviderName)
                .Member(d => d.ProviderKey, s => s.ProviderKey)
                /*
                .Member(d => d.PartitionKey, s =>s.PartitionKey)
                .Member(d => d.RowKey, s => s.RowKey)
                .Member(d => d.Id, s => s.Id)
                .Member(d => d.Deleted, s => s.Deleted)
                .Member(d => d.Published, s => s.Published)
                .Member(d => d.CreatedUtc, s => s.CreatedUtc)
                .Member(d => d.CreatedBy, s => s.CreatedBy)
                .Member(d => d.LastUpdatedUtc, s => s.LastUpdatedUtc)
                .Member(d => d.LastUpdatedBy, s => s.LastUpdatedBy)
                .Member(d => d.Name, s => s.Description)
                .Member(d => d.ProviderName, s => s.ProviderName)
                .Member(d => d.ProviderKey, s => s.ProviderKey)
                */
                //.Ignore(d => d.PartitionKey)
                //.Ignore(d => d.RowKey)
                //.Ignore(d => d.Id)
                //.Ignore(d => d.Deleted)
                //.Ignore(d => d.Published)
                //.Ignore(d => d.CreatedUtc)
                //.Ignore(d => d.CreatedBy)
                //.Ignore(d => d.LastUpdatedUtc)
                //.Ignore(d => d.LastUpdatedBy)
                //.Ignore(d => d.Name)
                //.Ignore(d => d.ProviderName)
                //.Ignore(d => d.ProviderKey)
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

            serviceCollection.AddTransient<IStoreTokenService, StoreTokenService>();

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
