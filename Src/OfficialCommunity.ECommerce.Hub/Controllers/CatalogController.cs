using System;
using System.Net;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger
            , IServiceProvider services
        )
        {
            _logger = logger;

            var providers = services.GetServices<IFulfillmentService>();
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            //ViewBag.FulfillmentProviders 
            return View();
        }

        [Authorize]
        public async Task<ActionResult> Catalogs([DataSourceRequest] DataSourceRequest request)
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Catalogs")
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
            }

            return new StatusCodeResult((int)HttpStatusCode.BadRequest);
        }
    }
}