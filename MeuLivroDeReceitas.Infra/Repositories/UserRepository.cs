using MeuLivroDeReceitas.Domain.Entities;
using MeuLivroDeReceitas.Domain.Repositories;
using MeuLivroDeReceitas.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace MeuLivroDeReceitas.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MeuLivroDeRecitasDbContext _context;

        public UserRepository(MeuLivroDeRecitasDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user) => await _context.Users.AddAsync(user);

        public async Task<bool> ExistActiveUserWithEmail(string email) => await _context.Users.AnyAsync(u => u.Email.Equals(email) && u.Active);
    }
}
