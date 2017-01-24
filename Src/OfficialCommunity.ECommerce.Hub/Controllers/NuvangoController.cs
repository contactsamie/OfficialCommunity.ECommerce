using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OfficialCommunity.ECommerce.Hub.Controllers
{
    [Authorize]
    public class NuvangoController : Controller
    {
        private readonly ILogger<NuvangoController> _logger;

        public NuvangoController(ILogger<NuvangoController> logger
            )
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}