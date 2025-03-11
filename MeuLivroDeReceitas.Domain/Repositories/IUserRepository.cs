using MeuLivroDeReceitas.Domain.Entities;

namespace MeuLivroDeReceitas.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public Task<bool> ExistActiveUserWithEmail(string email);
        public Task<User?> GetUserByEmailAndPassword(string email, string password);
    }
}
