using System;
using ExpressMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Nuvango.Infrastructure;
using OfficialCommunity.Necropolis.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Nuvango
{
    public class Module : IModule
    {
        public void RegisterMappings()
        {
            Mapper.Register<ECommerce.Domains.Business.Address, Domains.Business.Address>();
            Mapper.Register<Domains.Business.Address, ECommerce.Domains.Business.Address>()
                .Ignore(dest => dest.Address3);

            Mapper.Register<ECommerce.Domains.Business.Customer, Domains.Business.Address>()
                .Ignore(dest => dest.Address1)
                .Ignore(dest => dest.Address2)
                .Ignore(dest => dest.City)
                .Ignore(dest => dest.Company)
                .Ignore(dest => dest.FirstName)
                .Ignore(dest => dest.LastName)
                .Ignore(dest => dest.Country)
                .Ignore(dest => dest.Region)
                .Ignore(dest => dest.Zip)
                ;
            Mapper.Register<Domains.Business.Address, ECommerce.Domains.Business.Customer>()
                .Ignore(dest => dest.EMail)
                .Ignore(dest => dest.Fax)
                ;

            Mapper.Register<ECommerce.Domains.Business.BasketLine, Domains.Business.OrderItem>()
                .Member(dest => dest.Id, src => int.Parse(src.Sku))
                ;

            Mapper.Register<Domains.Business.ShippingRate, ECommerce.Domains.Business.ShippingRate>();

            Mapper.Register<Domains.Business.ProductOption, ECommerce.Domains.Business.ProductOption>();

            Mapper.Register<Domains.Business.ProductVariant, ECommerce.Domains.Business.ProductVariant>()
                .Member(dest => dest.Id, src => src.Id.ToString())
                ;

            Mapper.Register<Domains.Business.Product, ECommerce.Domains.Business.Product>()
                .Member(dest => dest.Id, src => src.Id.ToString())
                ;

            Mapper.Compile();
        }

        public void ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
        }

        public void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISession, Session>();
        }

        public void Configure(IConfiguration configuration, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
        }
    }
}
