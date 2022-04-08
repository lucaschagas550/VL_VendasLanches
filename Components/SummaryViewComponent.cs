using Microsoft.AspNetCore.Mvc;

namespace VL_VendasLanches.Components
{
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}