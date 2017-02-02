using System;
using ExpressMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Hub.Domains.Viewable;
using OfficialCommunity.ECommerce.Isotope.Services;
using OfficialCommunity.ECommerce.Nuvango;
using OfficialCommunity.ECommerce.Nuvango.Services;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.ECommerce.Services.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using Common = OfficialCommunity.ECommerce.Domains.Business;
using CommonService = OfficialCommunity.ECommerce.Services.Domains.Commands;

namespace OfficialCommunity.ECommerce.Hub
{
    public class Module : IModule
    {
        //public static IList<EditableConfiguration> MapConfiguration(Dictionary<string, string> configuration)
        //{
        //    return configuration.ToList()
        //}

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
        }

        public void ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
        }

        public void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IFulfillmentService, IsotopeService>();

            serviceCollection.Configure<NuvangoConfiguration>(configuration.GetSection("NuvangoConfiguration"));
            serviceCollection.AddTransient<IFulfillmentService, NuvangoService>();

            serviceCollection.Configure<LockService.LockServiceConfiguration>(configuration.GetSection("LockServiceConfiguration"));
            serviceCollection.AddTransient<ILockService, LockService>();

        }

        public void Configure(IConfiguration configuration, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
        }
    }
}
