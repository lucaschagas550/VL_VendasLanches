using Microsoft.EntityFrameworkCore;
using VL_VendasLanches.Context;
using VL_VendasLanches.Models;
using VL_VendasLanches.Repositories.Interfaces;

namespace VL_VendasLanches.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext context)
        {
            _context=context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanche.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanche
                                                        .Where(l => l.IsLanchePreferido)
                                                        .Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanche.FirstOrDefault(l => l.LancheId.Equals(lancheId));
        }
    }
}
