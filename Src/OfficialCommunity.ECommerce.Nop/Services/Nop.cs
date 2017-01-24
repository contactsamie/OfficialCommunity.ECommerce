using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Nop.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Infrastructure;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;
using Order = OfficialCommunity.ECommerce.Domains.Business.Order;

namespace OfficialCommunity.ECommerce.Nop.Services
{
    public class Nop
    {
        private readonly ILogger<Nop> _logger;
        private readonly NopCommerceDbContext _context;

        public Nop(ILogger<Nop> logger
                     , NopCommerceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        private static readonly IList<Order> GetOrdersToBePlacedError = null;
        public async Task<IStandardResponse<IList<Order>>> GetOrdersToBePlaced(
            string passport
            , string fufillmentProvider
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("GetOrdersToBePlaced")
                    .Data(nameof(fufillmentProvider), fufillmentProvider)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    return GetOrdersToBePlacedError.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    //_logger.LogError();.LogError((LoggingEvents.INSERT_ITEM, e, "Async error");
                    return GetOrdersToBePlacedError.GenerateStandardError("Operation Failed");
                }
            }
        }

        private static readonly IList<Order> GetOrdersNotShippedError = null;
        public async Task<IStandardResponse<IList<Order>>> GetOrdersNotShipped(
            string passport
            , string fufillmentProvider
        )
        {
            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("GetOrdersNotShipped")
                    .Data(nameof(fufillmentProvider), fufillmentProvider)
                    .EntryContext
                ;
            using (_logger.BeginScope(entry))
            {
                try
                {
                    return GetOrdersNotShippedError.GenerateStandardResponse();
                }
                catch (Exception e)
                {
                    //_logger.LogError();.LogError((LoggingEvents.INSERT_ITEM, e, "Async error");
                    return GetOrdersNotShippedError.GenerateStandardError("Operation Failed");
                }
            }
        }

    }
}
