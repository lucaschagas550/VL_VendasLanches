using Microsoft.AspNetCore.Mvc;

namespace VL_VendasLanches.Controllers
{
    public class AdminController : Controller
    {
        public string Index()
        {
            return $"Teste o metodo Index de AdminController: {DateTime.Now}";
        }

        public string Demo()
        {
            return $"Teste o metodo Demo de AdminController: {DateTime.Now}";
        }
    }
}
