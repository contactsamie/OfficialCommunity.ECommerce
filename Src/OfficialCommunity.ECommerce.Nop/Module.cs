using System;
using ExpressMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Nop.Domains.Business;
using OfficialCommunity.ECommerce.Nop.Services;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using Common = OfficialCommunity.ECommerce.Domains.Business;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace OfficialCommunity.ECommerce.Nop
{
    public class Module : IModule
    {
        public static Common.ShippingState MapShippingState(int state)
        {
            switch (state)
            {
                case Constants.ShippingStatusShippingNotRequired:
                    return Common.ShippingState.Error;
                case Constants.ShippingStatusNotYetShipped:
                    return Common.ShippingState.NotYetShipped;
                case Constants.ShippingStatusPartiallyShipped:
                    return Common.ShippingState.PartiallyShipped;
                case Constants.ShippingStatusShipped:
                case Constants.ShippingStatusDelivered:
                    return Common.ShippingState.Shipped;
                default:
                    return Common.ShippingState.Unknown;
            }
        }

        public void RegisterMappings()
        {
            Mapper.Register<Customer, Common.Customer>()
                .Member(dest => dest.FirstName, src => src.ShippingAddress.FirstName)
                .Member(dest => dest.LastName, src => src.ShippingAddress.LastName)
                .Member(dest => dest.EMail, src => src.ShippingAddress.Email)
                .Member(dest => dest.Phone, src => src.ShippingAddress.PhoneNumber)
                ;

            Mapper.Register<Address, Common.Address>()
                .Member(dest => dest.FirstName, src => src.FirstName)
                .Member(dest => dest.LastName, src => src.LastName)
                .Member(dest => dest.Company, src => src.Company)
                .Member(dest => dest.Address1, src => src.Address1)
                .Member(dest => dest.Address2, src => src.Address2)
                .Member(dest => dest.City, src => src.City)
                .Member(dest => dest.RegionCode, src => src.StateProvince != null ? src.StateProvince.Abbreviation : string.Empty)
                .Member(dest => dest.CountryCode, src => src.Country.ThreeLetterIsoCode)
                .Member(dest => dest.Zip, src => src.ZipPostalCode)
                ;

            Mapper.Register<OrderItem, Common.OrderItem>()
                .Function(dest => dest.ShippingState, src => MapShippingState(src.ShippingStatus))
                .Member(dest => dest.Id, src => src.Id.ToString())
                .Member(dest => dest.Name, src => src.Product.Name)
                .Member(dest => dest.Quantity, src => src.Quantity)
                .Member(dest => dest.Sku, src => src.Product.FulfillmentPartnerSku)
                .Member(dest => dest.UnitPrice, src => src.Product.Price)
                ;

            Mapper.Register<Order, Common.Store>()
                .Value(dest => dest.Provider, Constants.Provider)
                .Member(dest => dest.Id, src => src.StoreId.ToString())
                .Ignore(dest => dest.Name)
                .Ignore(dest => dest.Url)
                ;

            Mapper.Register<Order, Common.Order>()
                .Function(dest => dest.ShippingState, src => MapShippingState(src.ShippingStatusId))
                .Member(dest => dest.StoreOrderId, src => src.Id.ToString())
                .Member(dest => dest.TimeStampUtc, src => src.CreatedOnUtc)
                .Member(dest => dest.Currency, src => src.CustomerCurrencyCode)
                .Member(dest => dest.Tax, src => src.OrderTax)
                .Member(dest => dest.SubtotalPrice, src => src.OrderSubtotalInclTax)
                .Member(dest => dest.Discounts, src => src.OrderDiscount)
                .Member(dest => dest.TotalPrice, src => src.OrderTotal)
                .Member(dest => dest.Customer, src => src.Customer)
                .Member(dest => dest.ShippingAddress, src => src.ShippingAddress)
                .Member(dest => dest.OrderItems, src => src.OrderItem)
                .Member(dest => dest.Store, src => src)
                .Ignore(dest => dest.ShippingRate)
                .Ignore(dest => dest.FufillmentOrderId) // Filled in during attribute lookup
                ;
        }

        public void ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
        }

        public void ConfigureServices(IConfiguration configuration, IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IStoreServiceFactory, NopService.Factory>();
        }

        public void Configure(IConfiguration configuration, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
        }
    }
}
