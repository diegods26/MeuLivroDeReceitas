using MeuLivroDeReceitas.Domain.Entities;

namespace MeuLivroDeReceitas.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public Task<bool> ExistActiveUserWithEmail(string email);
    }
}
