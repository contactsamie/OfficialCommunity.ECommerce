using System;
using ExpressMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Hub.Domains.Viewable;
using OfficialCommunity.ECommerce.Nuvango;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using Common = OfficialCommunity.ECommerce.Domains.Business;
using CommonService = OfficialCommunity.ECommerce.Services.Domains.Commands;

namespace OfficialCommunity.ECommerce.Hub
{
    public class Module : IModule
    {
        public void RegisterMappings()
        {
            Mapper.Register<Common.Customer, ViewableCustomer>();
            Mapper.Register<Common.Address, ViewableAddress>();
            Mapper.Register<Common.ShippingRate, ViewableShippingRate>();
            Mapper.Register<Common.OrderItem, ViewableOrderItem>();
            Mapper.Register<Common.Order, ViewableOrder>();
            Mapper.Register<Common.Product, ViewableProduct>()
                .Ignore(dest => dest.Variants)
                ;

            Mapper.Register<CommonService.GetProductsCountResponse, ViewableProductCount>();
        }

        public void ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
        }

        public void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<NuvangoConfiguration>(configuration.GetSection("NuvangoConfiguration"));
            serviceCollection.AddTransient<ICatalogProvider, Nuvango.Services.Nuvango>();
            serviceCollection.AddTransient<IShippingProvider, Nuvango.Services.Nuvango>();
        }

        public void Configure(IConfiguration configuration, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
        }
    }
}
