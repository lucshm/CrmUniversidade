using Microsoft.EntityFrameworkCore;
using UnescCRM.Models;

namespace UnescCRM.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Manifestacao> Manifestacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder.Entity<Manifestacao>().ToTable("manifestacao");
        }
    }
}
