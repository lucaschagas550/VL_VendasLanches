using VL_VendasLanches.Models;

namespace VL_VendasLanches.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual{ get; set; }
    }
}
