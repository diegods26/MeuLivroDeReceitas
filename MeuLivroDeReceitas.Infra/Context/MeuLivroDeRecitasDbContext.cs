using MeuLivroDeReceitas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeuLivroDeReceitas.Infra.Context
{
    public class MeuLivroDeRecitasDbContext : DbContext
    {
        public MeuLivroDeRecitasDbContext(DbContextOptions<MeuLivroDeRecitasDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuLivroDeRecitasDbContext).Assembly);
        }
    }
}
