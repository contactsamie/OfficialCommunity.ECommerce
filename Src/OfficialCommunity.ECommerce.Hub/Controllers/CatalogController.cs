using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.ECommerce.Services.Domains.Services;
using OfficialCommunity.Necropolis.Infrastructure;
using ExpressMapper;
using OfficialCommunity.ECommerce.Hub.Domains.Editable;
using OfficialCommunity.ECommerce.Services.Domains.Business;

namespace OfficialCommunity.ECommerce.Hub.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly ICatalogEntityService _catalogEntityService;

        public CatalogController(ILogger<CatalogController> logger
            , IServiceProvider services
            , ICatalogEntityService catalogEntityService
        )
        {
            _logger = logger;
            _catalogEntityService = catalogEntityService;

            //var providers = services.GetServices<IFulfillmentService>();
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Index")
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var catalog = await _catalogEntityService.Read(passport);

                    if (catalog.HasError)
                    {
                        //_logger.LogError(e, "Product count error");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);

                    }

                    ViewBag.Catalogs = Mapper.Map<IEnumerable<CatalogTableEntity>, IList<EditableCatalogTableEntity>>(catalog.Response);

                    return View();

                }
                catch (Exception e)
                {
                    //_logger.LogError(e,
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
        }
    }
}