using VL_VendasLanches.Models;

namespace VL_VendasLanches.ViewModels
{
    public class PedidoLancheViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes{ get; set; }
    }
}
