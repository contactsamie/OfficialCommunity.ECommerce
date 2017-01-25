using System;
using OfficialCommunity.ECommerce.Nop.Domains.Business;

namespace OfficialCommunity.ECommerce.Nop.Tests
{
    public class TestData
    {
        public class Nop
        {
            public static Customer Customer = new Customer
            {
                ShippingAddress = new Address
                {
                    FirstName = "Art",
                    LastName = "Vandelay",
                    Email = "art.vandelay@dontexist.com",
                    PhoneNumber = "617-111-1111"
                }
            };

            public static Address AddressWithRegion = new Address
            {
                FirstName = "Art",
                LastName = "Vandelay",
                Company = "Vandelay Industries",
                Address1 = "1234 Sesame St",
                Address2 = "Unit 6",
                City = "Boston",

                StateProvince = new StateProvince
                {
                    Abbreviation = "MA"
                },

                Country = new Country
                {
                    ThreeLetterIsoCode = "USA"
                },

                ZipPostalCode = "02212"
            };

            public static Address AddressWithoutRegion = new Address
            {
                FirstName = "Art",
                LastName = "Vandelay",
                Company = "Vandelay Industries",
                Address1 = "1234 Sesame St",
                Address2 = "Unit 6",
                City = "Boston",

                Country = new Country
                {
                    ThreeLetterIsoCode = "USA"
                },

                ZipPostalCode = "02212"
            };

            public static OrderItem OrderItemShippingStatusShippingNotRequired = new OrderItem
            {
                Id = 100,
                Product = new Product
                {
                    Name = "Test",
                    FulfillmentPartnerSku = "SKU",
                    Price = 100M
                },
                Quantity = 1,
                ShippingStatus = Constants.ShippingStatusShippingNotRequired
            };

            public static OrderItem OrderItemShippingStatusNotYetShipped = new OrderItem
            {
                Id = 100,
                Product = new Product
                {
                    Name = "Test",
                    FulfillmentPartnerSku = "SKU",
                    Price = 100M
                },
                Quantity = 1,
                ShippingStatus = Constants.ShippingStatusNotYetShipped
            };

            public static OrderItem OrderItemShippingStatusPartiallyShipped = new OrderItem
            {
                Id = 100,
                Product = new Product
                {
                    Name = "Test",
                    FulfillmentPartnerSku = "SKU",
                    Price = 100M
                },
                Quantity = 1,
                ShippingStatus = Constants.ShippingStatusPartiallyShipped
            };

            public static OrderItem OrderItemShippingStatusShipped = new OrderItem
            {
                Id = 100,
                Product = new Product
                {
                    Name = "Test",
                    FulfillmentPartnerSku = "SKU",
                    Price = 100M
                },
                Quantity = 1,
                ShippingStatus = Constants.ShippingStatusShipped
            };

            public static OrderItem OrderItemShippingStatusDelivered = new OrderItem
            {
                Id = 100,
                Product = new Product
                {
                    Name = "Test",
                    FulfillmentPartnerSku = "SKU",
                    Price = 100M
                },
                Quantity = 1,
                ShippingStatus = Constants.ShippingStatusDelivered
            };

            public static OrderItem OrderItemShippingStatusUnknown = new OrderItem
            {
                Id = 100,
                Product = new Product
                {
                    Name = "Test",
                    FulfillmentPartnerSku = "SKU",
                    Price = 100M
                },
                Quantity = 1,
                ShippingStatus = -1
            };

            public static Order Order = new Order
            {
                Id = 1000,
                StoreId = 10,
                CreatedOnUtc = DateTime.UtcNow,
                CustomerCurrencyCode = "CAD",
                OrderTax = 10M,
                OrderSubtotalInclTax = 110M,
                OrderDiscount = 1,
                OrderTotal = 1000M,
                Customer = new Customer
                {
                    ShippingAddress = AddressWithRegion
                },
                ShippingAddress = AddressWithRegion
            };
        }
    }
}
