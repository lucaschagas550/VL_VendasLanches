using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VL_VendasLanches.Models;
using VL_VendasLanches.Repositories.Interfaces;
using VL_VendasLanches.ViewModels;

namespace VL_VendasLanches.Controllers;

public class HomeController : Controller
{
    private readonly ILancheRepository _lancheRepositorys;

    public HomeController(ILancheRepository lancheRepositorys)
    {
        _lancheRepositorys=lancheRepositorys;
    }

    public IActionResult Index()
    {
        #region
        //TempData["Nome"] = "Lucas"; 
        // TempData é um valor temporario que existe até ser recuperado, pode ser enviado para outra controller ou action, view para controller ou inverso
        #endregion

        var homeViewModel = new HomeViewModel
        {
            LanchesPreferidos = _lancheRepositorys.LanchesPreferidos,
        };

        return View(homeViewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
