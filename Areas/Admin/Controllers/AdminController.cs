using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VL_VendasLanches.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")] // tem que estar com perfi de admin
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
