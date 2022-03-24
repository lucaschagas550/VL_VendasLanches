using VL_VendasLanches.Context;

namespace VL_VendasLanches.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext appContext)
        {
            _context=appContext;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set;}

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //Define uma sessao
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; 

            //obtem um servico do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessao
            session.SetString("CarrinhoId", carrinhoId);

            //retorna carrinho com contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId,
            };
        }
    }
}
