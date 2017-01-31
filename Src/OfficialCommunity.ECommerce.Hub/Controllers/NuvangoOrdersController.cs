using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ExpressMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Domains.Business;
using OfficialCommunity.ECommerce.Hub.Domains.Viewable;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Extensions;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Controllers
{
    [Authorize]
    public class NuvangoOrdersController : Controller
    {
        private readonly ILogger<NuvangoOrdersController> _logger;
        private readonly IOrdersService _orders;

        public NuvangoOrdersController(ILogger<NuvangoOrdersController> logger
            , IOrdersService orders
        )
        {
            _logger = logger;
            _orders = orders;
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
                    var count = await _orders.GetOrdersCount(passport);
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
                    .Data(nameof(request), request)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var count = await _orders.GetOrdersCount(passport);
                    if (count.LogErrorsIfAny("GetOrdersCount Failed", _logger))
                    {
                        return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                    }

                    var page = request.Page;
                    var orders = await _orders.GetOrders(passport, page);
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