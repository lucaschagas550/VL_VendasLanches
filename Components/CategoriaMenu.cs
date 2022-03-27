using Microsoft.AspNetCore.Mvc;
using VL_VendasLanches.Repositories.Interfaces;

namespace VL_VendasLanches.Components
{
    [ViewComponent]
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository=categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categorias = _categoriaRepository.Categorias.OrderBy(c => c.CategoriaNome);
            return View(categorias);
        }
    }
}
