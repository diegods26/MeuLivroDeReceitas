using MeuLivroDeReceitas.Domain.Repositories;
using MeuLivroDeReceitas.Infra.Context;

namespace MeuLivroDeReceitas.Infra
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeuLivroDeRecitasDbContext _context;

        public UnitOfWork(MeuLivroDeRecitasDbContext context)
        {
            _context = context;
        }

        public async Task Commit() => await _context.SaveChangesAsync();
    }
}
