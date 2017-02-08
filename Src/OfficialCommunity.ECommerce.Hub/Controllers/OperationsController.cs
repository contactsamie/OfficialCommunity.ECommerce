using System;
using System.Collections.Generic;
using System.Linq;
using ExpressMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficialCommunity.ECommerce.Hub.Data;
using OfficialCommunity.ECommerce.Hub.Domains.Infrastructure;
using OfficialCommunity.ECommerce.Hub.Domains.Viewable;
using OfficialCommunity.ECommerce.Hub.Extensions;

namespace OfficialCommunity.ECommerce.Hub.Controllers
{
    [Authorize]
    public class OperationsController : Controller
    {
        private readonly ECommerceDbContext _db;

        public OperationsController(ECommerceDbContext db)
        {
            _db = db;
        }

        public IActionResult Operations()
        {
            return View();
        }

        [Authorize]
        public ActionResult _Log(Guid id)
        {
            return PartialView(id);
        }

        [Authorize]
        public ActionResult _Request(Guid id)
        {
            return PartialView(id);
        }

        [Authorize]
        public ActionResult _Response(Guid id)
        {
            return PartialView(id);
        }

        [Authorize]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(_db.Operations.ToDataSourceResult(request, Mapper.Map<Operation,ViewableOperation>));
        }

        [Authorize]
        public ActionResult ReadLogById(Guid id)
        {
            return Json(AsViewableMessagesFromJson(id
                , (db, i) => db.Operations.FirstOrDefault(x => x.Id == i)?.Log));
        }

        [Authorize]
        public ActionResult ReadRequestById(Guid id)
        {
            return Json(AsViewableMessagesFromJson(id
                , (db, i) => db.Operations.FirstOrDefault(x => x.Id == i)?.Request));
        }

        [Authorize]
        public ActionResult ReadResponseById(Guid id)
        {
            return Json(AsViewableMessagesFromJson(id
                , (db, i) => db.Operations.FirstOrDefault(x => x.Id == i)?.Response));
        }

        private IList<ViewableMessage> AsViewableMessagesFromJson(Guid id
            , Func<ECommerceDbContext, Guid, string> extract)
        {
            var result = new List<ViewableMessage>();
            var data = extract?.Invoke(_db, id);
            if (!string.IsNullOrWhiteSpace(data))
            {
                var json = JsonConvert.DeserializeObject(data);
                var document = JsonConvert.SerializeObject(json, Formatting.Indented);
                result.AddRange(document.ToViewableMessages());
            }
            return result;
        }
    }
}