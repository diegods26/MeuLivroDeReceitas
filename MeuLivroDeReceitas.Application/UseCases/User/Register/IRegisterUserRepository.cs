using MeuLivroDeReceitas.Comminication.Requests;
using MeuLivroDeReceitas.Comminication.Responses;

namespace MeuLivroDeReceitas.Application.UseCases.User.Register
{
    public interface IRegisterUserRepository
    {
        public Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);
    }
}
