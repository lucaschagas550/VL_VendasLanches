using Microsoft.AspNetCore.Mvc;
using VL_VendasLanches.Models;
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

        public IActionResult List(string categoria)
        {
            #region
            //ViewData["Titulo"] = "Todos os lanches";    //atribuindo valor na ViewData para ser recuperado na view List 
            //ViewData["Data"] = DateTime.Now;
            //ViewBag.TotalLanches = "Total Lanches:";    //atribuindo valor na ViewBag para ser recuperado na view List , viewbag eh mais usado, porem viewData um pouco mais rapido
            //ViewBag.TotalLanchesCount = lanches.Count();
            #endregion

            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;
            
            if(string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.CategoriaId); 
                categoriaAtual = "Todos os lacnhes";
            }else
            {
                if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase)) //StringComparison.OrdinalIgnoreCase ignora caixa alta ou baixa
                {
                    lanches = _lancheRepository.Lanches
                                .Where(l => l.Categoria.CategoriaNome.ToLower().Equals("Normal".ToLower()))
                                .OrderBy(l => l.Nome);
                }else
                {
                    lanches = _lancheRepository.Lanches
                                .Where(l => l.Categoria.CategoriaNome.ToLower().Equals("Natural".ToLower()))
                                .OrderBy(l => l.Nome);
                }
                categoriaAtual = categoria;
            }

            var lanchesViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesViewModel); //enviando para view um IEnumerable de lanches
        }
    }
}
