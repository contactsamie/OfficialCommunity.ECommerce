using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Nop.Domains.Business;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;
using Order = OfficialCommunity.ECommerce.Domains.Business.Order;

namespace OfficialCommunity.ECommerce.Nop.Services
{
    public class Nop : IStoreProvider
    {
        private readonly ILogger<Nop> _logger;
        private readonly NopCommerceDbContext _context;

        public Nop(ILogger<Nop> logger
                     , NopCommerceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public string Provider => Constants.Provider;

        private static readonly IList<Order> GetOrdersToBePlacedError = null;
        public async Task<IStandardResponse<IList<Order>>> GetNewOrders(
            string passport
            , string fufillmentProvider
            , string attributeOrderId
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("GetOrdersToBePlaced")
                    .Data(nameof(fufillmentProvider), fufillmentProvider)
                    .Data(nameof(attributeOrderId), attributeOrderId)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var items = await _context.OrderItem
                                        .Where(oi => !oi.Order.Deleted
                                                        && oi.ShippingStatus == Constants.ShippingStatusNotYetShipped
                                                        && oi.Product.FulfillmentPartner.ToLower() == fufillmentProvider.ToLower()
                                                        && oi.Order.OrderStatusId == Constants.OrderStatusProcessing
                                        )
                                        .ToListAsync();

                    var newItems = items.Where(oi => !_context.GenericAttribute
                                                        .Any(ga => ga.EntityId == oi.OrderId
                                                                   && ga.KeyGroup == "Order"
                                                                   && ga.Key == attributeOrderId
                                                        ))
                                        .ToList();

                    var orders = newItems.GroupBy(oi => oi.Order);

                    return GetOrdersToBePlacedError.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Nop Error");
                    return GetOrdersToBePlacedError.GenerateStandardError("Operation Failed");
                }
            }
        }

        private static readonly IList<Order> GetOrdersNotShippedError = null;
        public async Task<IStandardResponse<IList<Order>>> GetUnshippedOrders(
            string passport
            , string fufillmentProvider
            , string attributeOrderId
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("GetOrdersNotShipped")
                    .Data(nameof(fufillmentProvider), fufillmentProvider)
                    .Data(nameof(attributeOrderId), attributeOrderId)
                    .EntryContext
                ;
            using (_logger.BeginScope(entry))
            {
                try
                {
                    var items = await _context.OrderItem
                                        .Where(oi => !oi.Order.Deleted
                                                        && oi.ShippingStatus == Constants.ShippingStatusNotYetShipped
                                                        && oi.Product.FulfillmentPartner.ToLower() == fufillmentProvider.ToLower()
                                                        && oi.Order.OrderStatusId == Constants.OrderStatusProcessing
                                        )
                                        .ToListAsync();

                    var unshippedItems = items.Where(oi => _context.GenericAttribute
                                                                    .Any(ga => ga.EntityId == oi.OrderId
                                                                               && ga.KeyGroup == "Order"
                                                                               && ga.Key == attributeOrderId
                                                                    ))
                                        .ToList();

                    var orders = unshippedItems.GroupBy(oi => oi.Order);

                    return GetOrdersNotShippedError.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Nop Error");
                    return GetOrdersNotShippedError.GenerateStandardError("Operation Failed");
                }
            }
        }

    }
}
