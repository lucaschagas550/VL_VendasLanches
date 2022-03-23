using Microsoft.AspNetCore.Mvc;
using VL_VendasLanches.Repositories.Interfaces;
using VL_VendasLanches.ViewModels;

namespace VL_VendasLanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository=lancheRepository;
        }

        public IActionResult List()
        {
            #region
            //ViewData["Titulo"] = "Todos os lanches";    //atribuindo valor na ViewData para ser recuperado na view List 
            //ViewData["Data"] = DateTime.Now;
            //ViewBag.TotalLanches = "Total Lanches:";    //atribuindo valor na ViewBag para ser recuperado na view List , viewbag eh mais usado, porem viewData um pouco mais rapido
            //ViewBag.TotalLanchesCount = lanches.Count();
            #endregion

            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _lancheRepository.Lanches;
            lancheListViewModel.CategoriaAtual = "Categoria";
            return View(lancheListViewModel); //enviando para view um IEnumerable de lanches
        }
    }
}
