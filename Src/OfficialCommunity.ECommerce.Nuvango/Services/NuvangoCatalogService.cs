using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressMapper;
using Newtonsoft.Json.Linq;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Nuvango.Domains.Messages;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Exceptions;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Nuvango.Services
{
    public partial class NuvangoService : IFufillmentCatalogService
    {
        private const string GetProductsCountApi = "products/count";
        private static readonly ECommerce.Services.Domains.Commands.GetEntityCountResponse GetProductsCountError = null;
        public async Task<IStandardResponse<ECommerce.Services.Domains.Commands.GetEntityCountResponse>> GetProductsCount(
            string passport
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(GetProductsCountApi)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var response = await _session.GetAsync<GetEntityCountResponse>(GetProductsCountApi);
                    return Mapper.Map<GetEntityCountResponse, ECommerce.Services.Domains.Commands.GetEntityCountResponse>(response)
                        .GenerateStandardResponse();
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
            string passport
            , int page
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(GetProductsApi)
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
            string passport
            , string id
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(GetProductApi)
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
    }
}