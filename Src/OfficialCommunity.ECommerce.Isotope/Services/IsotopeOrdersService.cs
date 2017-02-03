using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Isotope.Services
{
    public partial class IsotopeService : IFufillmentOrdersService
    {
        private static readonly bool PlaceOrderError = false;
        public async Task<IStandardResponse<bool>> PlaceOrder(
            string passport
            , Cart cart
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("PlaceOrder")
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {

                try
                { 
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                }
            }
            return PlaceOrderError.GenerateStandardError("Operation Failed");
        }

        private static readonly ECommerce.Services.Domains.Commands.GetEntityCountResponse GetOrdersCountError = null;
        public async Task<IStandardResponse<ECommerce.Services.Domains.Commands.GetEntityCountResponse>> GetOrdersCount(
            string passport
            )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("GetOrdersCount")
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                }
            }
            return GetOrdersCountError.GenerateStandardError("Operation Failed");
        }

        private static readonly IList<Order> GetOrdersError = null;
        public async Task<IStandardResponse<IList<Order>>> GetOrders(
            string passport
            , int page
            )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("GetOrders")
                    .Data(nameof(page), page)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                }
            }
            return GetOrdersError.GenerateStandardError("Operation Failed");
        }

        private static readonly Order GetOrderError = null;
        public async Task<IStandardResponse<Order>> GetOrder(
            string passport
            , string id
            )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("GetOrder")
                    .Identity(nameof(id), id)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Async error");
                }
            }
            return GetOrderError.GenerateStandardError("Operation Failed");
        }
    }
}