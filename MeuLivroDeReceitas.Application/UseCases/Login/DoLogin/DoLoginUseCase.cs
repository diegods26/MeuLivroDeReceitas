using MeuLivroDeReceitas.Application.Services.Cryptography;
using MeuLivroDeReceitas.Comminication.Requests;
using MeuLivroDeReceitas.Comminication.Responses;
using MeuLivroDeReceitas.Domain.Repositories;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;

namespace MeuLivroDeReceitas.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordEncrypter _passwordEncrypter;

        public DoLoginUseCase(IUserRepository userRepository, PasswordEncrypter passwordEncrypter)
        {
            _userRepository = userRepository;
            _passwordEncrypter = passwordEncrypter;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestLoginJson request)
        {
            var passwordEncrypted = _passwordEncrypter.Encrypt(request.Password);
            var user = await _userRepository
                .GetUserByEmailAndPassword(request.Email, passwordEncrypted) ?? throw new InvalidLoginException();

            return new ResponseRegisterUserJson
            {
                Name = user.Name
            };
        }
    }
}
