using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Console;
using OfficialCommunity.Necropolis.Infrastructure;

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
            RegionCode = "Ontario",
            CountryCode = "Canada",
            Zip = "M6P 2L9"
        };

        public static CartItem _cartItem = new CartItem
        {
            Id = "CA546AB4-84E0-4541-8C12-077124146545",
            Sku = "",
            Quantity = 10,
        };

        static void Main(string[] args)
        {
            try
            {
                Application.Startup();

                var passport = Passport.Generate();

                var logger = Application.ServiceProvider.GetService<ILogger<Program>>();
                var catalog = Application.ServiceProvider.GetService<ICatalogProvider>();

                var count = catalog.GetProductsCount(passport).Result;
                logger.LogInformation($"Count {count}");

                var products = catalog.GetProducts(passport, 1).Result;

                var productToShip = products.Response.Last();
                var variantToShip = productToShip.Variants.Last();

                _cartItem.Sku = variantToShip.Id;

                var cart = new List<CartItem>
                {
                    _cartItem
                };

                var shipping = Application.ServiceProvider.GetService<IShippingProvider>();

                var rates = shipping.GetShippingRates(passport
                                                        , _address
                                                        , "CAD"
                                                        , cart
                                                        ).Result;
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
