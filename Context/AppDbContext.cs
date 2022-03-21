using Microsoft.EntityFrameworkCore;
using VL_VendasLanches.Models;

namespace VL_VendasLanches.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get;  set; }
        public DbSet<Lanche> Lanche { get; set; }
    }
}
