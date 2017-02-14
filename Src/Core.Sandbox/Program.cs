using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using ExpressMapper;
using Jose;
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
                var entityId = Guid.NewGuid();

                var logger = Application.ServiceProvider.GetService<ILogger<Program>>();

                var tokenService = Application.ServiceProvider.GetService<IStoreTokenService>();

                var secretBytes = tokenService.GenerateSecretAsBytes(32);
                var store = tokenService.LookupStoreAsync(passport,
                    "eyJhbGciOiJBMjU2R0NNS1ciLCJlbmMiOiJBMjU2Q0JDLUhTNTEyIiwidHlwIjoiSldUIiwiY3R5IjoiSldUIiwiZW50aXR5SWQiOiI2MWMxNjU4Yi1hMmM0LTRkMzUtYmE2NS05YWVkMTVkNDRiYjUiLCJpdiI6IkpaNjk3aWxJckFoYUo4VEQiLCJ0YWciOiJNUk1TejdUZHgtdXo5Sm15WjNGVTJBIiwiemlwIjoiREVGIn0.1EzGKQ7IWr1HslbU85lCx-_NWqodsBaAYz4TX1lqWiswDpC_HIK8xEOXxfJePWs-mayUEQch_2jddPDe59OnxQ.c6R880m6_flU8ubTYWKARQ.54cGfJguNqJTb_CEMNoMhQ.HCKhWpSttWtkkt4JWOYG--W8Jq3kpSQxtn4tsGByrnI").Result;

                var secretBytesAsString = Convert.ToBase64String(secretBytes.Response);
                var asSecretBytes = Convert.FromBase64String(secretBytesAsString);

                var secret = tokenService.GenerateSecretAsString();
                if (secret.HasError)
                {
                    Console.WriteLine(secret.BuildError());
                }
                else
                {
                    var salt = tokenService.GenerateSecretAsBytes(8);
                    if (salt.HasError)
                    {
                        Console.WriteLine(salt.BuildError());
                    }
                    else
                    {
                        byte[] token;
                        using (var generator = new Rfc2898DeriveBytes(secret.Response
                                                                        , salt.Response
                                                                        , 300))
                        {
                            token = generator.GetBytes(32);
                        }

                        //var token = tokenService.GenerateToken(secret.Response, entityId);
                        //if (token.HasError)
                        //{
                        //    Console.WriteLine(token.BuildError());
                        //}
                    }
                }

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

