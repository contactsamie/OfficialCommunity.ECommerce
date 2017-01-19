using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Nuvango.Domains.Messages;
using OfficialCommunity.ECommerce.Nuvango.Infrastructure;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Nuvango.Services
{
    public class Nuvango : IShippingProvider
    {
        private readonly ILogger _logger;
        private readonly ISession _session;

        public Nuvango(ILogger logger, ISession session)
        {
            _logger = logger;
            _session = session;
        }

        private const string GetShippingRatesApi = "shipping_rates";
        private static readonly IList<ShippingRate> GetShippingRatesError = null;
        public async Task<IStandardResponse<IList<ShippingRate>>> GetShippingRates(
            Customer customer
            , Address address
            , string currency
            , IList<BasketLine> items
            )
        {
            var entry = EntryContext.Capture
                    .Passport("")
                    .Name(GetShippingRatesApi)
                    .Identity(nameof(customer), customer)
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
                    ShippingAddress = Domains.Business.Address.From(customer, address),
                    OrderItems = items.Select(Domains.Business.OrderItem.From).ToList()
                };

                try
                {
                    var response = await _session.PostAsync<IList<ShippingRate>, GetRatesRequest>(GetShippingRatesApi, request);
                    return response.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    //_logger.LogError();.LogError((LoggingEvents.INSERT_ITEM, e, "Async error");
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
                    //_logger.LogError();.LogError((LoggingEvents.INSERT_ITEM, e, "Async error");
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
                    .Data(nameof(page),page)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var resource = $"{GetProductsApi}?page={page}";
                    var response = await _session.GetAsync<IList<Product>>(resource);
                    return response.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    //_logger.LogError();.LogError((LoggingEvents.INSERT_ITEM, e, "Async error");
                    return GetProductsError.GenerateStandardError("Operation Failed");
                }
            }
        }

        private static Product DeserializeProduct(string json)
        {
            try
            {
                var parse = JToken.Parse(json);

                var @object = (JObject) parse;
                if (@object == null)
                    return null;

                var id = 

                var product = new Product();

                return product;
            }
            catch
            {
                return null;
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
                    var response = await _session.GetAsync<Product>(resource);
                    return response.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    //_logger.LogError();.LogError((LoggingEvents.INSERT_ITEM, e, "Async error");
                    return GetProductError.GenerateStandardError("Operation Failed");
                }
            }
        }

        private static IList<Product> DeserializeProducts(string json)
        {
            return null;
        }

    }
}
