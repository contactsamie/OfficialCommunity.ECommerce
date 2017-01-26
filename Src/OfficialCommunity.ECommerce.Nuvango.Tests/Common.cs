using System;
using System.Collections.Generic;
using OfficialCommunity.ECommerce.Domains.Business;
using Common = OfficialCommunity.ECommerce.Domains.Business;

namespace OfficialCommunity.ECommerce.Nuvango.Tests
{
    public class TestData
    {
        public class Address
        {
            public static Common.Address Test = new Common.Address
            {
                FirstName = "Art",
                LastName = "Vandelay",
                Company = "Vandelay Industries",
                Address1 = "1234 Sesame St",
                Address2 = "Unit 6",
                City = "Boston",
                RegionCode = "MA",
                CountryCode = "USA",
                Zip = "02212"
            };
        }

        public class Customer
        {
            public static Common.Customer Test = new Common.Customer
            {
                FirstName = "Art",
                LastName = "Vandelay",
                EMail = "art.vandelay@dontexist.com",
                Phone = "617-111-1111"
            };
        }

        public class CartItem
        {
            public static Common.CartItem Test = new Common.CartItem
            {
                Id = "CA546AB4-84E0-4541-8C12-077124146545",
                Sku = "100",
                Quantity = 10,
            };
        }

        public class OrderItem
        {
            public static Common.OrderItem Test = new Common.OrderItem
            {
                Id = "1000",
                UnitPrice = 100M,
                Quantity = 10,
            };
        }
        public class Order
        {
            public static Common.Order Test = new Common.Order
            {
                StoreOrderId = "1000",
                TimeStampUtc = DateTime.UtcNow,
                ShippingState = ShippingState.NotYetShipped,
                Currency = "CAD",
                Tax = 10M,
                SubtotalPrice = 100M,
                Discounts = 1M,
                TotalPrice = 111M,
                OrderItems = new List<Common.OrderItem>
                {
                    new Common.OrderItem
                    {
                        Id = "1000",
                        UnitPrice = 100M,
                        Quantity = 10,
                    },
                    new Common.OrderItem
                    {
                        Id = "2000",
                        UnitPrice = 200M,
                        Quantity = 20,
                    },
                }
            };
        }

        public class ShippingRate
        {
            public static Common.ShippingRate Test = new Common.ShippingRate
            {
                Name = "CanadaPost:Regular Parcel:DOM.EP",
                Currency = "CAD",
                Price = 25.0M,
                Json = @"{
                    'carrier': 'CanadaPost',
                    'title': 'Regular Parcel',
                    'code': 'DOM.EP',
                    'price': 25.00,
                    'currency': 'CAD'
                }"
            };
        }

        public class ProductOption
        {
            public static Common.ProductOption Test = new Common.ProductOption
            {
                Name = "Size",
                Values = new List<string>
                {
                    "Small"
                    , "Medium"
                    , "Large"
                    , "Extra Large"
                }
            };
        }

        public class ProductVariant
        {
            public static Common.ProductVariant Test = new Common.ProductVariant
            {
                Id = "CA546AB4-84E0-4541-8C12-077124146541",
                Options = new List<Common.ProductOption>
                {
                    new Common.ProductOption
                    {
                        Name = "Size",
                        Values = new List<string>
                        {
                            "S", "M", "L"
                        }
                    },
                    new Common.ProductOption
                    {
                        Name = "Model",
                        Values = new List<string>
                        {
                            "6", "6s"
                        }
                    }
                }
            };
        }
    }

    public class Nuvango
    {
        public class Address
        {
            public static Domains.Business.Address Test = new Domains.Business.Address
            {
                FirstName = "Art",
                LastName = "Vandelay",
                Company = "Vandelay Industries",
                Address1 = "1234 Sesame St",
                Address2 = "Unit 6",
                City = "Toronto",
                RegionCode = "ON",
                CountryCode = "CAN",
                Zip = "M6P 2L9",
                Phone = "617-999-0999"
            };
        }

        public class OrderItem
        {
            public static Domains.Business.OrderItem Test = new Domains.Business.OrderItem
            {
                Id = 200,
                UnitPrice = 100M,
                Quantity = 1,
            };
        }

        public class Order
        {
            public static Domains.Business.Order Test = new Domains.Business.Order
            {
                OrderNumber = "2000",
            };
        }

        public class ShippingRate
        {
            public static Domains.Business.ShippingRate Test = new Domains.Business.ShippingRate
            {
                Carrier = "CanadaPost",
                Title = "Regular Parcel",
                Code = "DOM-EP",
                Currency = "CAD",
                Price = 25.0M
            };
        }

        public class ProductOption
        {
            public static Domains.Business.ProductOption Test = new Domains.Business.ProductOption
            {
                Name = "Style",
                Values = new List<string>
                {
                    "White Border"
                    , "Black Border"
                    , "Gallery Mount"
                }
            };
        }

        public class ProductVariant
        {
            public static Domains.Business.ProductVariant Test = new Domains.Business.ProductVariant
            {
                Id = 1000,
                Options = new List<Domains.Business.ProductOption>
                {
                    new Domains.Business.ProductOption
                    {
                        Name = "Size",
                        Values = new List<string>
                        {
                            "Small"
                        }
                    },
                    new Domains.Business.ProductOption
                    {
                        Name = "Model",
                        Values = new List<string>
                        {
                            "6"
                        }
                    }
                }
            };
        }

        public class Product
        {
            public static Domains.Business.Product Test = new Domains.Business.Product
            {
                Id = 1000,
                Name = "Women's Leggings - Bookshelf",
                Options = new List<Domains.Business.ProductOption>
                {
                    new Domains.Business.ProductOption
                    {
                        Name = "Size",
                        Values = new List<string>
                        {
                            "Small", "Medium", "Large", "Extra Large"
                        }
                    },
                    new Domains.Business.ProductOption
                    {
                        Name = "Model",
                        Values = new List<string>
                        {
                            "6", "6s"
                        }
                    }
                },
                Variants = new List<Domains.Business.ProductVariant>
                {
                    new Domains.Business.ProductVariant
                    {
                        Id = 9000,
                        Options = new List<Domains.Business.ProductOption>
                        {
                            new Domains.Business.ProductOption
                            {
                                Name = "Size",
                                Values = new List<string>
                                {
                                    "Small"
                                }
                            },
                            new Domains.Business.ProductOption
                            {
                                Name = "Model",
                                Values = new List<string>
                                {
                                    "6"
                                }
                            }
                        }
                    },
                    new Domains.Business.ProductVariant
                    {
                        Id = 9001,
                        Options = new List<Domains.Business.ProductOption>
                        {
                            new Domains.Business.ProductOption
                            {
                                Name = "Size",
                                Values = new List<string>
                                {
                                    "Medium"
                                }
                            },
                            new Domains.Business.ProductOption
                            {
                                Name = "Model",
                                Values = new List<string>
                                {
                                    "6"
                                }
                            }
                        }
                    },
                    new Domains.Business.ProductVariant
                    {
                        Id = 9001,
                        Options = new List<Domains.Business.ProductOption>
                        {
                            new Domains.Business.ProductOption
                            {
                                Name = "Size",
                                Values = new List<string>
                                {
                                    "Large"
                                }
                            },
                            new Domains.Business.ProductOption
                            {
                                Name = "Model",
                                Values = new List<string>
                                {
                                    "6"
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
