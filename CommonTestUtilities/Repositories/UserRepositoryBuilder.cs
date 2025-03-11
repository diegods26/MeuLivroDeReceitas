using MeuLivroDeReceitas.Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories
{
    public class UserRepositoryBuilder
    {
        private readonly Mock<IUserRepository> _repository;

        public UserRepositoryBuilder() => _repository = new Mock<IUserRepository>();
        public IUserRepository Build() => _repository.Object;
        public void ExistActiveUserWithEmail(string email)
        {
            _repository.Setup(rep => rep.ExistActiveUserWithEmail(email)).ReturnsAsync(true);
        }
    }
}
