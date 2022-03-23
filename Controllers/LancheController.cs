using Microsoft.AspNetCore.Mvc;
using VL_VendasLanches.Repositories.Interfaces;

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
            var lanches = _lancheRepository.Lanches;
            return View(lanches); //enviando para view um IEnumerable de lanches
        }
    }
}
