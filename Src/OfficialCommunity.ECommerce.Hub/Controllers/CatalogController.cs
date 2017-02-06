using System;
using System.Collections.Generic;
using System.Linq;
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
using Kendo.Mvc.Extensions;
using Microsoft.Azure.Documents;
using OfficialCommunity.ECommerce.Hub.Domains.Editable;
using OfficialCommunity.ECommerce.Hub.Domains.Viewable;
using OfficialCommunity.ECommerce.Services.Domains.Business;
using OfficialCommunity.Necropolis.Domains.Services;
using OfficialCommunity.Necropolis.Extensions;

namespace OfficialCommunity.ECommerce.Hub.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private const int CACHE_DURATION_IN_SECONDS = 60 * 10;
        private const string FULFILLMENT_PROVIDERS_ALL_KEY = "urn:cache:fufillment.providers.all";

        private readonly ILogger<CatalogController> _logger;
        private readonly ICatalogEntityService _catalogEntityService;
        private readonly ICacheManager _cache;
        private readonly IServiceProvider _services;

        public CatalogController(ILogger<CatalogController> logger
            , IServiceProvider services
            , ICacheManager cache
            , ICatalogEntityService catalogEntityService
        )
        {
            _logger = logger;
            _cache = cache;
            _services = services;
            _catalogEntityService = catalogEntityService;
        }

        private static async Task<IList<ViewableForeignKey<string>>> GetAllFulfillmentProviders(IServiceProvider services)
        {
            return services.GetServices<IFulfillmentService>()
                            .Select(x => new ViewableForeignKey<string>
                            {
                                Key = x.Key.ToString("D"),
                                Name = x.Name
                            }).ToList();
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
                    ViewBag.ProviderKeys = await _cache.AcquireAsync(FULFILLMENT_PROVIDERS_ALL_KEY
                                                                , CACHE_DURATION_IN_SECONDS
                                                                , _services
                                                                , services => GetAllFulfillmentProviders(services)
                                                                );

                    var catalog = await _catalogEntityService.Read(passport);

                    if (catalog.HasError)
                    {
                        _logger.LogError("Catalog Read failed");
                        return new StatusCodeResult((int)HttpStatusCode.InternalServerError);

                    }

                    ViewBag.Catalogs = Mapper.Map<IEnumerable<CatalogTableEntity>, IList<EditableCatalogTableEntity>>(catalog.Response);

                    return View();

                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Index Failed");
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, EditableCatalogTableEntity entity)
        {
            return Json(new[] { entity }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, EditableCatalogTableEntity entity)
        {
            return Json(new[] { entity }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, EditableCatalogTableEntity entity)
        {
            entity.Deleted = true;
            return Json(new[] { entity }.ToDataSourceResult(request, ModelState));
        }
    }
}