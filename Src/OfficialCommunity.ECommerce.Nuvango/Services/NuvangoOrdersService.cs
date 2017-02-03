using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpressMapper;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Nuvango.Domains.Messages;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Nuvango.Services
{
    public partial class NuvangoService : IFufillmentOrdersService
    {
        private const string PlaceOrderApi = "orders";
        private static readonly bool PlaceOrderError = false;
        public async Task<IStandardResponse<bool>> PlaceOrder(
            string passport
            , Cart cart
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(PlaceOrderApi)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                var request = Mapper.Map<Cart, PlaceOrderRequest>(cart);
                Mapper.Map(cart.Customer, request.Address);

                try
                {
                    var response = await _session.PostAsync(PlaceOrderApi, request);
                    return response.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                    return PlaceOrderError.GenerateStandardError("Operation Failed");
                }
            }
        }

        private const string GetOrdersCountApi = "orders/count";
        private static readonly ECommerce.Services.Domains.Commands.GetEntityCountResponse GetOrdersCountError = null;
        public async Task<IStandardResponse<ECommerce.Services.Domains.Commands.GetEntityCountResponse>> GetOrdersCount(
            string passport
            )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(GetOrdersCountApi)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var response = await _session.GetAsync<GetEntityCountResponse>(GetOrdersCountApi);
                    return Mapper.Map<GetEntityCountResponse, ECommerce.Services.Domains.Commands.GetEntityCountResponse>(response)
                                    .GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                    return GetOrdersCountError.GenerateStandardError("Operation Failed");
                }
            }
        }

        private const string GetOrdersApi = "orders";
        private static readonly IList<Order> GetOrdersError = null;
        public async Task<IStandardResponse<IList<Order>>> GetOrders(
            string passport
            , int page
            )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(GetOrdersApi)
                    .Data(nameof(page), page)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var resource = $"{GetOrdersApi}?page={page}";
                    var orders = await _session.GetAsync<List<Domains.Business.Order>>(resource);

                    var commonOrders = Mapper.Map<IList<Domains.Business.Order>, IList<Order>>(orders);

                    foreach (var commonOrder in commonOrders)
                    {
                        foreach (var item in commonOrder.OrderItems)
                        {
                            item.ShippingState = commonOrder.ShippingState;
                        }
                    }

                    return commonOrders.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                    return GetOrdersError.GenerateStandardError("Operation Failed");
                }
            }
        }

        private const string GetOrderApi = "orders";
        private static readonly Order GetOrderError = null;
        public async Task<IStandardResponse<Order>> GetOrder(
            string passport
            , string id
            )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(GetOrderApi)
                    .Identity(nameof(id), id)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var resource = $"{GetOrderApi}/{id}";
                    var order = await _session.GetAsync<Domains.Business.Order>(resource);

                    var commonOrder = Mapper.Map<Domains.Business.Order, Order>(order);

                    foreach (var item in commonOrder.OrderItems)
                    {
                        item.ShippingState = commonOrder.ShippingState;
                    }

                    return commonOrder.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                    return GetOrderError.GenerateStandardError("Operation Failed");
                }
            }
        }
    }
}
