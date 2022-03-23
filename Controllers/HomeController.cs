using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VL_VendasLanches.Models;

namespace VL_VendasLanches.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        #region
        //TempData["Nome"] = "Lucas"; 
        // TempData é um valor temporario que existe até ser recuperado, pode ser enviado para outra controller ou action, view para controller ou inverso
        #endregion

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
