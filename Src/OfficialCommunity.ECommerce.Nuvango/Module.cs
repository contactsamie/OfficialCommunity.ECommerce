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
        public static Common.ShippingState MapShippingState(ShippingState state)
        {
            switch (state)
            {
                case ShippingState.Ready:
                case ShippingState.InProgress:
                    return Common.ShippingState.NotYetShipped;
                case ShippingState.Fulfilled:
                    return Common.ShippingState.Shipped;
            }
            return Common.ShippingState.Unknown;
        }

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
            Mapper.Register<Common.CartItem, CartItem>()
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

            Mapper.Register<Common.Cart, PlaceOrderRequest>()
                .Member(dest => dest.OrderNumber, src => src.StoreOrderId)
                .Member(dest => dest.Customer, src => src.Customer)
                .Member(dest => dest.ShippingRate, src => src.ShippingRate)
                .Member(dest => dest.Address, src => src.ShippingAddress)
                .Member(dest => dest.OrderItems, src => src.Items)
                ;

            //---------------------------------------

            Mapper.Register<Order, Common.Order>()
                .Member(dest => dest.StoreOrderId, src => src.OrderNumber)
                .Member(dest => dest.FufillmentOrderId, src => src.OrderNumber)
                .Member(dest => dest.TimeStampUtc, src => src.TimeStampUtc)
                .Member(dest => dest.Currency, src => src.Currency)
                .Function(dest => dest.ShippingState, src => MapShippingState(src.ShippingState))
                .Member(dest => dest.Tax, src => src.Tax)
                .Member(dest => dest.SubtotalPrice, src => src.SubtotalPrice)
                .Member(dest => dest.Discounts, src => src.Discounts)
                .Member(dest => dest.TotalPrice, src => src.TotalPrice)
                .Member(dest => dest.Customer, src => src.Customer)
                .Member(dest => dest.ShippingAddress, src => src.ShippingAddress)
                .Member(dest => dest.Discounts, src => src.Discounts)
                .Member(dest => dest.ShippingRate, src => src.ShippingRate)
                .Member(dest => dest.OrderItems, src => src.OrderItems)
                ;

            //---------------------------------------

            Mapper.Register<GetEntityCountResponse, ECommerce.Services.Domains.Commands.GetEntityCountResponse>();
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
