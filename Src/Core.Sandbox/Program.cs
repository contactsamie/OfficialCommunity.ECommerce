using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Nuvango.Domains.Messages;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.Necropolis.Console;
using OfficialCommunity.Necropolis.Exceptions;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;
using OfficialCommunity.Necropolis.Services;

[assembly: UserSecretsId("Core.Sandbox-20170120015008")]

namespace Core.Sandbox
{
    public class Program
    {
        private static Customer _customer = new Customer
        {
            FirstName = "Bob",
            LastName = "Builder",
            EMail = "bobbuilder@notnow.com",
            Phone = "416-666-7777"
        };

        public static Address _address = new Address
        {
            FirstName = "Bob",
            LastName = "Builder",
            Company = "bb inc",
            Address1 = "1234 Sesame St",
            Address2 = "Unit 6",
            City = "Toronto",
            RegionCode = "ON",
            CountryCode = "CA",
            Zip = "M6P 2L9"
        };

        public static CartItem _cartItem = new CartItem
        {
            Sku = "",
            Quantity = 10,
            UnitPrice = 1M
        };

        static void Main(string[] args)
        {
            try
            {
                Application.Startup();

                var passport = Passport.Generate();

                var logger = Application.ServiceProvider.GetService<ILogger<Program>>();

                /*
                var tokenService = new TokenService();
                var secret = tokenService.GenerateSecret();
                if (secret.HasError)
                {
                    Console.WriteLine(secret.BuildError());
                }
                else
                {
                    Console.WriteLine(secret.Response);
                    var encoded = tokenService.Encode(secret.Response,1);
                    if (encoded.HasError)
                    {

                        Console.WriteLine(encoded.BuildError());
                    }
                    else
                    {
                        var valid = tokenService.IsValid(encoded.Response, secret.Response);
                        if (valid.HasError)
                        {
                            Console.WriteLine(valid.BuildError());
                        }
                        else
                        {
                            Console.WriteLine(valid.Response);
                        }
                    }
                }
                */

                /*
                var factory = Application.ServiceProvider.GetServices<IStoreServiceFactory>()
                                                            .First(x => x.Name.ToLower() == "nop");

                var properties = new Dictionary<string, string>
                {
                    { "ConnectionString", "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=trackingForAddedColumn;Integrated Security=True;Persist Security Info=False;MultipleActiveResultSets=True" }
                };

                var provider = factory.GetInstance(passport, properties).Result;
                if (provider.HasError)
                    Console.WriteLine("ERROR:" + provider.StandardError.Errors.First());
                else
                {
                    var orders = provider.Response.GetNewOrders(passport, "nuvango", "nuvango-order-id").Result;
                }
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }
    }
}

//var fufillmentServices = Application.ServiceProvider.GetServices<IFulfillmentService>();
//var fufillmentService = fufillmentServices.First();
//var lockService = Application.ServiceProvider.GetService<ILockService>();
//var catalogService = Application.ServiceProvider.GetService<ICatalogEntityService>();

/*
var providerConfiguration = new Dictionary<string, string>();
foreach (var property in fufillmentService.ConfigurationProperties())
{
    providerConfiguration[property] = string.Empty;
}

for (var i = 0; i < 50; i++)
{
    var catalog = new CatalogTableEntity
    {
        Name = "Catalog - Test - " + i,
        Description = "Test catalog",
        ProviderName = fufillmentService.Name,
        ProviderKey = fufillmentService.Key.ToString("D"),
        ProviderConfiguration = providerConfiguration
    };

    var result = catalogService.Create(passport, catalog, Environment.UserName).Result;
}

var catalogs = catalogService.Read(passport).Result;

//var result = lockService.Read(passport, "LOCKNAME", "1111").Result;
//result = lockService.Release(passport, "LOCKNAME", "guid").Result;
*/
/*
var logger = Application.ServiceProvider.GetService<ILogger<Program>>();
var catalog = Application.ServiceProvider.GetService<ICatalogService>();

var count = catalog.GetProductsCount(passport).Result;
logger.LogInformation($"Count {count}");

var products = catalog.GetProducts(passport, 1).Result;

var productToShip = products.Response.Last();
var variantToShip = productToShip.Variants.Last();

_cartItem.Sku = variantToShip.Id;

var cartItems = new List<CartItem>
{
    _cartItem
};

var shipping = Application.ServiceProvider.GetService<IShippingService>();

var rates = shipping.GetShippingRates(passport
                                        , _address
                                        , "CAD"
                                        , cartItems
                                        ).Result;

var shippingRate = rates.Response.First();

var orders = Application.ServiceProvider.GetService<IOrdersService>();

var now = DateTime.UtcNow;
var cart = new Cart
{
    StoreOrderId = $"{now:y_M_d_hh_mm}",
    TimeStampUtc = now,
    Currency = "CAD",
    Tax = 0M,
    SubtotalPrice = 10M,
    Discounts = 0M,
    TotalPrice = 10M,
    Customer = _customer,
    ShippingAddress = _address,
    ShippingRate = shippingRate,
    Items = cartItems
};

//var request = Mapper.Map<Cart, PlaceOrderRequest>(cart);
//Mapper.Map(_customer, request.Address);

var placed = orders.PlaceOrder(passport, cart).Result;
*/

