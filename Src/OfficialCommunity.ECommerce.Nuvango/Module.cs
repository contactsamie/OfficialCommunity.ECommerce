using System;
using ExpressMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OfficialCommunity.ECommerce.Nuvango.Domains.Business;
using OfficialCommunity.ECommerce.Nuvango.Domains.Messages;
using OfficialCommunity.ECommerce.Nuvango.Infrastructure;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using Common = OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Nuvango
{
    public class Module : IModule
    {
        public void RegisterMappings()
        {
            Mapper.Register<Common.Address, Address>();
            Mapper.Register<Address, Common.Address>();
            //---------------------------------------
            Mapper.Register<Common.Customer, Address>()
                .Ignore(dest => dest.Address1)
                .Ignore(dest => dest.Address2)
                .Ignore(dest => dest.City)
                .Ignore(dest => dest.Company)
                .Ignore(dest => dest.FirstName)
                .Ignore(dest => dest.LastName)
                .Ignore(dest => dest.CountryCode)
                .Ignore(dest => dest.RegionCode)
                .Ignore(dest => dest.Zip)
                ;
            Mapper.Register<Address, Common.Customer>()
                .Ignore(dest => dest.EMail)
                ;
            //---------------------------------------
            Mapper.Register<Common.CartItem, OrderItem>()
                .Member(dest => dest.Id, src => int.Parse(src.Sku))
                ;
            //---------------------------------------
            //Mapper.Register<Common.OrderItem, OrderItem>()
            //    .Member(dest => dest.Id, src => int.Parse(src.Id))
            //    ;
            Mapper.Register<OrderItem, Common.OrderItem>()
                .Member(dest => dest.Id, src => src.Id.ToString())
                ;
            //---------------------------------------
            //Mapper.Register<Common.Order, Order>()
            //    .Member(dest => dest.OrderNumber, src => src.Id)
            //        .Function(dest => dest.ShippingState,
            //src =>
            //{
            //    switch (src.ShippingState)
            //    {
            //        case Common.ShippingState.Unknown:
            //            return ShippingState.Ready;
            //        case 2:
            //            return GenderTypes.Men;
            //        default:
            //            return GenderTypes.Unisex;
            //    }
            //})
            //;
            //Mapper.Register<Order, Common.Order>()
            //    .Member(dest => dest.Id, src => src.OrderNumber)
            //    ;
            //---------------------------------------
            Mapper.Register<ShippingRate, Common.ShippingRate>()
                .Member(dest => dest.Name, src => $"{src.Carrier}:{src.Title}:{src.Code}")
                .Member(dest => dest.Currency, src => src.Currency)
                .Member(dest => dest.Price, src => src.Price)
                .Function(dest => dest.Json, JsonConvert.SerializeObject)
                ;
            Mapper.Register<Common.ShippingRate, ShippingRate>()
                .Instantiate(src => JsonConvert.DeserializeObject<ShippingRate>(src.Json))
                ;
            //---------------------------------------
            Mapper.Register<ProductOption, Common.ProductOption>();
            //Mapper.Register<Common.ProductOption, ProductOption>();
            //---------------------------------------
            Mapper.Register<ProductVariant, Common.ProductVariant>()
                .Member(dest => dest.Id, src => src.Id.ToString())
                ;
            //Mapper.Register<Common.ProductVariant, ProductVariant>()
            //    .Member(dest => dest.Id, src => int.Parse(src.Id))
            //    ;
            //---------------------------------------
            Mapper.Register<Product, Common.Product>()
                .Member(dest => dest.Id, src => src.Id.ToString())
                ;
            //Mapper.Register<Common.Product, Product>()
            //    .Member(dest => dest.Id, src => int.Parse(src.Id))
            //    ;

            //---------------------------------------

            Mapper.Register<Common.Order, PlaceOrderRequest>()
                .Member(dest => dest.OrderNumber, src => src.StoreOrderId)
                .Ignore(dest => dest.Customer)
                .Ignore(dest => dest.Address)
                .Ignore(dest => dest.ShippingRate)
                ;
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
