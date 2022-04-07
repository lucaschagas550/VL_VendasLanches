using Microsoft.AspNetCore.Mvc;
using VL_VendasLanches.ViewModels;

namespace VL_VendasLanches.Components
{
    [ViewComponent]
    public class PaginacaoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPagedList modeloPaginado)
        {
            return View(modeloPaginado);
        }
    }
}
