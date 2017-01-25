using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Nuvango.Domains.Messages;
using OfficialCommunity.ECommerce.Nuvango.Infrastructure;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Exceptions;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Nuvango.Services
{
    public class Nuvango :
        ICatalogProvider
        , IShippingProvider
        , IOrderProvider
    {
        private readonly ILogger<Nuvango> _logger;
        private readonly ISession _session;

        public Nuvango(ILogger<Nuvango> logger, ISession session)
        {
            _logger = logger;
            _session = session;
        }

        private const string GetShippingRatesApi = "shipping_rates";
        private static readonly IList<ShippingRate> GetShippingRatesError = null;
        public async Task<IStandardResponse<IList<ShippingRate>>> GetShippingRates(
            Address address
            , string currency
            , IList<CartItem> items
            )
        {
            var entry = EntryContext.Capture
                    .Passport("")
                    .Name(GetShippingRatesApi)
                    .Data(nameof(address), address)
                    .Data(nameof(currency), currency)
                    .Data(nameof(items), items)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                var request = new GetRatesRequest
                {
                    Currency = currency,
                    City = address.City,
                    Region = address.RegionCode,
                    Country = address.CountryCode,
                    Zip = address.Zip,
                    OrderItems = Mapper.Map<IList<CartItem>, IList<Domains.Business.OrderItem>>(items).ToList()
                };

                try
                {
                    var response = await _session.PostAsync<IList<ShippingRate>, GetRatesRequest>(GetShippingRatesApi, request);
                    return response.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                    return GetShippingRatesError.GenerateStandardError("Operation Failed");
                }
            }
        }

        private const string GetProductsCountApi = "products/count";
        private static readonly int GetProductsCountError = 0;
        public async Task<IStandardResponse<int>> GetProductsCount(
            )
        {
            var entry = EntryContext.Capture
                    .Passport("")
                    .Name(GetProductsCountApi)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var response = await _session.GetAsync<GetProductsCountResponse>(GetProductsCountApi);
                    return response.Count.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                    return GetProductsCountError.GenerateStandardError("Operation Failed");
                }
            }
        }

        private const string GetProductsApi = "products";
        private static readonly IList<Product> GetProductsError = null;
        public async Task<IStandardResponse<IList<Product>>> GetProducts(
            int page
            )
        {
            var entry = EntryContext.Capture
                    .Passport("")
                    .Name(GetProductsCountApi)
                    .Data(nameof(page), page)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var resource = $"{GetProductsApi}?page={page}";
                    var products = await _session.GetAsync(resource, DeserializeProducts);

                    return Mapper.Map<IList<Domains.Business.Product>, IList<Product>>(products)
                            .GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                    return GetProductsError.GenerateStandardError("Operation Failed");
                }
            }
        }

        private const string GetProductApi = "products";
        private static readonly Product GetProductError = null;
        public async Task<IStandardResponse<Product>> GetProduct(
            string id
            )
        {
            var entry = EntryContext.Capture
                    .Passport("")
                    .Name(GetProductsCountApi)
                    .Identity(nameof(id), id)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var resource = $"{GetProductApi}/{id}";
                    var product = await _session.GetAsync(resource, DeserializeProduct);

                    return Mapper.Map<Domains.Business.Product, Product>(product)
                            .GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                    return GetProductError.GenerateStandardError("Operation Failed");
                }
            }
        }

        private static Domains.Business.Product DeserializeProduct(string json)
        {
            var parse = JToken.Parse(json);
            return DeserializeProduct(parse);
        }

        private static IList<Domains.Business.Product> DeserializeProducts(string json)
        {
            var parse = JArray.Parse(json);
            return parse.Children<JToken>().Select(DeserializeProduct).ToList();
        }

        private static Domains.Business.Product DeserializeProduct(JToken token)
        {
            var product = new Domains.Business.Product()
            {
                Options = new List<Domains.Business.ProductOption>(),
                Variants = new List<Domains.Business.ProductVariant>()
            };

            var idToken = token["id"];
            if (idToken != null)
            {
                var nameToken = token["name"];
                if (nameToken != null)
                {
                    var optionsToken = token["options"];
                    if (optionsToken != null)
                    {
                        var variantsToken = token["variants"];
                        if (variantsToken != null)
                        {
                            product.Id = idToken.Value<int>();
                            product.Name = nameToken.Value<string>();

                            foreach (var option in optionsToken)
                            {
                                var optionProperty = (JProperty)option;
                                var optionName = optionProperty.Name;
                                var optionValues = new List<string>();
                                var optionArrayToken = (JArray)optionProperty.Value;
                                if (optionArrayToken != null)
                                {
                                    optionValues.AddRange(optionArrayToken.Select(optionArrayTokenValue => optionArrayTokenValue.Value<string>()));
                                }

                                product.Options.Add(new Domains.Business.ProductOption
                                {
                                    Name = optionName,
                                    Values = optionValues
                                });
                            }

                            foreach (var variant in variantsToken)
                            {
                                var variantIdToken = variant["id"];
                                if (variantIdToken != null)
                                {
                                    var variantOptionsToken = variant["options"];
                                    if (variantOptionsToken != null)
                                    {
                                        var productVariant = new Domains.Business.ProductVariant
                                        {
                                            Id = variantIdToken.Value<int>(),
                                            Options = new List<Domains.Business.ProductOption>()
                                        };

                                        foreach (var variantOption in variantOptionsToken)
                                        {
                                            var variantOptionProperty = (JProperty)variantOption;
                                            var variantOptionName = variantOptionProperty.Name;
                                            var variantOptionValue = ((JValue)variantOptionProperty.Value).Value<string>();

                                            productVariant.Options.Add(new Domains.Business.ProductOption
                                            {
                                                Name = variantOptionName,
                                                Values = new List<string>
                                            {
                                                variantOptionValue
                                            }
                                            });
                                        }

                                        product.Variants.Add(productVariant);
                                    }
                                    else
                                    {
                                        var id = variantIdToken.Value<int>();
                                        throw new ContextException($"Missing Product Variant Options for Id {id}"
                                            , new
                                            {
                                                id,
                                                json = token.ToString()
                                            });
                                    }
                                }
                                else
                                {
                                    throw new ContextException("Missing Product Variant Id"
                                        , new
                                        {
                                            json = token.ToString()
                                        });
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new ContextException("Missing Product Name"
                        , new
                        {
                            json = token.ToString()
                        });
                }
            }
            else
            {
                throw new ContextException("Missing Product Id"
                    , new
                    {
                        json = token.ToString()
                    });
            }

            return product;
        }


        private const string PlaceOrderApi = "orders";
        private static readonly bool PlaceOrderError = false;
        public async Task<IStandardResponse<bool>> PlaceOrder(
            string passport
            , Customer customer
            , Address address
            , ShippingRate shippingRate
            , Order order
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(PlaceOrderApi)
                    .Data(nameof(customer), customer)
                    .Data(nameof(address), address)
                    .Data(nameof(shippingRate), shippingRate)
                    .Data(nameof(order), order)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                var request = Mapper.Map<Order, PlaceOrderRequest>(order);

                request.Customer = Mapper.Map<Customer, Domains.Business.Customer>(customer);
                request.Address = Mapper.Map<Address, Domains.Business.Address>(address);
                Mapper.Map(customer, request.Address);
                request.ShippingRate = Mapper.Map<ShippingRate, Domains.Business.ShippingRate>(shippingRate);

                try
                {
                    var response = await _session.PostAsync(GetShippingRatesApi, request);
                    return response.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                    return PlaceOrderError.GenerateStandardError("Operation Failed");
                }
            }
        }
    }
}
