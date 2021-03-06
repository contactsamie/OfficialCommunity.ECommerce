﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Nuvango;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Console;
using OfficialCommunity.Necropolis.Infrastructure;

namespace Sandbox
{
    class Program
    {
        private static string json =
@"{
   'id': 1242,
   'name': 'iPhone Skin - Devil Whale',
   'options': {
     'Model': ['6', '6S'],
     'Size': ['S', 'M', 'L']
   },
   'variants': [
     {
       'id': 124427,
       'options': {
         'Model': '6',
         'Size': 'S'
       }
     },
     {
       'id': 124428,
       'options': {
         'Model': '6S',
         'Size': 'M'
       }
     }
   ]
 }";

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
            Zip = "02212"
        };

        public static CartItem _basketLine = new CartItem
        {
            Sku = "",
            Quantity = 10,
        };


        static void Main(string[] args)
        {
            try
            {
                Application.Startup();

                var logger = Application.ServiceProvider.GetService<ILogger<Program>>();
                /*
                var catalog = Application.ServiceProvider.GetService<IFufillmentCatalogService>();

                var passport = Passport.Generate();

                var count = catalog.GetProductsCount(passport).Result;
                logger.LogInformation($"Count {count}");

                var products = catalog.GetProducts(passport, 1).Result;

                var productToShip = products.Response.Last();
                var variantToShip = productToShip.Variants.Last();

                _basketLine.Sku = variantToShip.Id;

                var items = new List<CartItem>
                {
                    _basketLine
                };

                var shipping = Application.ServiceProvider.GetService<IFufillmentShippingService>();

                var rates = shipping.GetShippingRates(passport, _address, "CAD", items).Result;
                */

                var properties = new Dictionary<string,string>
                {
                    { "EndPoint", "this is endpoint" },
                    { "Token", "this is token" },
                };

                var c = JsonConvert.DeserializeObject<Configuration>(JsonConvert.SerializeObject(properties));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }
    }

    public class Configuration
    {
        public string EndPoint { get; set; }
        public string Token { get; set; }
    }
}
