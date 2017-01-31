using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
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
using CommonService = OfficialCommunity.ECommerce.Services.Domains.Commands;

namespace OfficialCommunity.ECommerce.Hub.Controllers
{
    [Authorize]
    public class NuvangoCatalogController : Controller
    {
        private readonly ILogger<NuvangoCatalogController> _logger;
        private readonly ICatalogService _catalog;

        public NuvangoCatalogController(ILogger<NuvangoCatalogController> logger
            , ICatalogService catalog
            )
        {
            _logger = logger;
            _catalog = catalog;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> ProductCount()
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("ProductCount")
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var count = await _catalog.GetProductsCount(passport);
                    if (count.LogErrorsIfAny("GetProductsCount Failed", _logger))
                    {
                        return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                    }
                    return Json(Mapper.Map<CommonService.GetEntityCountResponse, ViewableProductCount>(count.Response));
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Product count error");
                    return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
        }

        [Authorize]
        public async Task<ActionResult> Products([DataSourceRequest]DataSourceRequest request)
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Products")
                    .Data(nameof(request), request)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var count = await _catalog.GetProductsCount(passport);
                    if (count.LogErrorsIfAny("GetProductsCount Failed", _logger))
                    {
                        return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                    }

                    var page = request.Page;
                    var products = await _catalog.GetProducts(passport, page);
                    if (products.LogErrorsIfAny("GetProducts Failed", _logger))
                    {
                        return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                    }

                    var viewableProducts = Mapper.Map<IList<Product>, IList<ViewableProduct>>(products.Response);
                    /*
                    var variants = new List<ViewableProductVariant>();
                    foreach (var product in products.Response)
                    {
                        foreach (var variant in product.Variants)
                        {
                            var sb = new StringBuilder();
                            foreach (var option in variant.Options)
                            {
                                sb.Append($"{option.Name}:{string.Join("|", option.Values)}");
                            }

                            variants.Add(new ViewableProductVariant
                            {
                                Id = product.Id,
                                Name = product.Name,
                                VariantId = variant.Id,
                                Options = sb.ToString()
                            });        
                        }
                    }
                    */
                    request.PageSize = viewableProducts.Count;
                    var result = viewableProducts.ToDataSourceResult(request);
                    result.Total = count.Response.Count;
                    return Json(result);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "ProductVariants error");
                    return new StatusCodeResult(500);
                }
            }
        }

        [Authorize]
        public async Task<ActionResult> Variants([DataSourceRequest]DataSourceRequest request, string id)
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Variants")
                    .Identity(nameof(id), id)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var product = await _catalog.GetProduct(passport,id);
                    if (product.LogErrorsIfAny("GetProduct Failed", _logger))
                    {
                        return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                    }

                    var variants = new List<ViewableProductVariant>();
                    foreach (var variant in product.Response.Variants)
                    {
                        var sb = new StringBuilder();
                        foreach (var option in variant.Options)
                        {
                            sb.Append($"{option.Name}:{string.Join("|", option.Values)}");
                        }

                        variants.Add(new ViewableProductVariant
                        {
                            Id = variant.Id,
                            Options = sb.ToString()
                        });
                    }

                    request.PageSize = variants.Count;
                    var result = variants.ToDataSourceResult(request);
                    result.Total = variants.Count;
                    return Json(result);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Variants error");
                    return new StatusCodeResult(500);
                }
            }
        }

        [Authorize]
        public async Task<ActionResult> Product(string id)
        {
            var passport = Passport.Generate();

            var entry = EntryContext.Capture
                    .Passport(passport)
                    .Name("Product")
                    .Identity(nameof(id), id)
                    .EntryContext
                ;

            using (_logger.BeginScope(entry))
            {
                try
                {
                    var product = await _catalog.GetProduct(passport, id);
                    if (product.LogErrorsIfAny("GetProduct Failed", _logger))
                    {
                        return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                    }
                    return Json(product);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Products error");
                    return new StatusCodeResult(500);
                }
            }
        }
    }
}