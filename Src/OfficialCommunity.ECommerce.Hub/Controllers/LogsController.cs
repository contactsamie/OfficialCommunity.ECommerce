using System.Xml.Linq;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficialCommunity.ECommerce.Hub.Data;

namespace OfficialCommunity.ECommerce.Hub.Controllers
{
    [Authorize]
    public class LogsController : Controller
    {
        private readonly ECommerceDbContext _db;

        public LogsController(ECommerceDbContext db)
        {
            _db = db;
        }

        [Authorize]
        public IActionResult Logs()
        {
            return View();
        }

        [Authorize]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var logs = _db.Logs.ToDataSourceResult(request, model =>
            {
                if (string.IsNullOrWhiteSpace(model.Properties)) return model;

                try
                {
                    var doc = XDocument.Parse(model.Properties);
                    model.Properties = doc.ToString();
                }
                catch
                {
                }
                return model;
            });

            return Json(logs);
        }
    }
}