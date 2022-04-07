using VL_VendasLanches.ViewModels;
using VL_VendasLanches.Models;

namespace VL_VendasLanches.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
        Task<IQueryable<Pedido>> Get();
        Task<PagedViewModel<Pedido>> ObterTodos(IQueryable<Pedido> source, int pageNumber, int pageSize, string query);
    }
}
