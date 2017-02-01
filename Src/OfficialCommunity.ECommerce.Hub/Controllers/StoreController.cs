using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OfficialCommunity.ECommerce.Hub.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
    }
}