using System;
using ExpressMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Hub.Domains.Viewable;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using Common = OfficialCommunity.ECommerce.Domains.Business;

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
        }

        public void ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
        }

        public void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
        {
        }

        public void Configure(IConfiguration configuration, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
        }
    }
}
