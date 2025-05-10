using demoFinal.entity;
using Microsoft.EntityFrameworkCore;

namespace demoFinal.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
