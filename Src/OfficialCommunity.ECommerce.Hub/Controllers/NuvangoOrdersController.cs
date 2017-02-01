using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ExpressMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Hub.Domains.Viewable;
using OfficialCommunity.ECommerce.Nuvango.Services;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Exceptions;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Controllers
{
    [Authorize]
    public class NuvangoOrdersController : Controller
    {
        private static readonly NuvangoService NullService = new NuvangoService(null,null);

        private readonly ILogger<NuvangoOrdersController> _logger;
        private readonly IFulfillmentService _fulfillment;

        public NuvangoOrdersController(ILogger<NuvangoOrdersController> logger
            , IServiceProvider services
        )
        {
            _logger = logger;
            _fulfillment = services.GetServices<IFulfillmentService>()
                    .First(x => x.Key == NullService.Key)
                ;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> OrdersCount()
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("OrderCount")
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var count = await _fulfillment.Orders.GetOrdersCount(passport);
                    if (count.LogErrorsIfAny("GetProductsCount Failed", _logger))
                    {
                        return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                    }
                    return Json(Mapper.Map<ECommerce.Services.Domains.Commands.GetEntityCountResponse, ViewableProductCount>(count.Response));
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Product count error");
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [Authorize]
        public async Task<ActionResult> Orders([DataSourceRequest]DataSourceRequest request)
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Orders")
                    .Identity("ordernumber",12)
                    .Data(nameof(request.Page), request.Page)
                    .Data(nameof(request.PageSize), request.PageSize)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                _logger.LogInformation("Information Test");
                try
                {
                    throw new ContextException("Unable to do something"
                        , new Exception("Original Exception")
                        , new
                        {
                            FailedOperation = "Insert"
                        });

                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Orders error");
                }

                try
                {
                    var count = await _fulfillment.Orders.GetOrdersCount(passport);
                    if (count.LogErrorsIfAny("GetOrdersCount Failed", _logger))
                    {
                        return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                    }

                    var page = request.Page;
                    var orders = await _fulfillment.Orders.GetOrders(passport, page);
                    if (orders.LogErrorsIfAny("GetOrders Failed", _logger))
                    {
                        return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                    }

                    var viewableOrders = Mapper.Map<IList<Order>, IList<ViewableOrder>>(orders.Response);

                    request.PageSize = viewableOrders.Count;
                    var result = viewableOrders.ToDataSourceResult(request);
                    result.Total = count.Response.Count;
                    return Json(result);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Orders error");
                    return new StatusCodeResult(500);
                }
            }
        }
    }
}