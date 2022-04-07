using Microsoft.EntityFrameworkCore;
using VL_VendasLanches.Context;
using VL_VendasLanches.Models;
using VL_VendasLanches.Repositories.Interfaces;

namespace VL_VendasLanches.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(AppDbContext appDbContext,
            CarrinhoCompra carrinhoCompra)
        {
            _appDbContext = appDbContext;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _appDbContext.Pedidos.Add(pedido);
            _appDbContext.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.LancheId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Lanche.Preco
                };
                _appDbContext.PedidoDetalhes.Add(pedidoDetail);
            }
            _appDbContext.SaveChanges();
        }

        public async Task<IQueryable<Pedido>> Get()
        {
            return _appDbContext.Set<Pedido>().AsNoTracking(); //asnotracking permite desabilitar o rastreamento de entidade e assim ganhar desempenho
            //o metodo set do contexto retonar uma instancia dbset<t> para o acesso a entidades de determinado tipo no contexto
        }

        public async Task<PagedViewModel<Pedido>> ObterTodos(IQueryable<Pedido> source, int pageNumber, int pageSize, string query)
        {
            var count = source.Count();
            var itens = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedViewModel<Pedido>()
            {
                List = itens,
                PageSize = pageSize,
                PageIndex = pageNumber,
                TotalResults = count
            };
        }
    }
}
