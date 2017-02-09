using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressMapper;
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
    public partial class NopService : Service, IStoreService
    {
        public class Configuration : IConfiguration
        {
            public string ConnectionString { get; set; }
        }

        //---------------------------------------

        private const string _name = "nop";
        private static readonly Guid _key = new Guid("EEA210B4-C6A7-4302-9566-503970F80289");

        //---------------------------------------

        private readonly ILogger<NopService> _logger;
        private readonly NopCommerceDbContext _context;

        public NopService(ILogger<NopService> logger
                     , NopCommerceDbContext context)
            : base(_name, _key)
        {
            _logger = logger;
            _context = context;
        }

        public string Provider => Constants.Provider;

        public async Task<IStandardResponse<IList<Order>>> GetNewOrders(
            string passport
            , string fufillmentProvider
            , string attributeOrderId
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name(nameof(GetNewOrders))
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
                                                        // TODO: Put back for production
                                                        //&& oi.ShippingStatus == Constants.ShippingStatusNotYetShipped
                                                        && oi.Product.FulfillmentPartner.ToLower() == fufillmentProvider.ToLower()
                                                        //&& oi.Order.OrderStatusId == Constants.OrderStatusProcessing
                                        )
                                        .Include(o => o.Product)
                                        .ToListAsync();

                    var newItems = items.Where(oi => !_context.GenericAttribute
                                                        .Any(ga => ga.EntityId == oi.OrderId
                                                                   && ga.KeyGroup == "Order"
                                                                   && ga.Key == attributeOrderId
                                                        ))
                                        .ToList();

                    var orderIds = newItems.Select(oi => oi.OrderId)
                                            .Distinct()
                                            .ToList();

                    var orders = await _context.Order
                                        .Where(o => orderIds.Contains(o.Id))
                                        .Include(o => o.ShippingAddress)
                                        .Include(o => o.Customer)
                                        .ToListAsync();

                    foreach (var order in orders)
                    {
                        order.OrderItem = newItems.Where(oi => oi.OrderId == order.Id).ToList();
                    }

                    var commonOrders = Mapper.Map<List<Domains.Business.Order>, IList<Order>>(orders);

                    return commonOrders.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Nop Error");
                    return default(IList<Order>).GenerateStandardError("Operation Failed");
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
                    .Name(nameof(GetUnshippedOrders))
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
                                        .Include(o => o.Product)
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
