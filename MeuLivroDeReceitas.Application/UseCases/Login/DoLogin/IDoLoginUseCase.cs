using MeuLivroDeReceitas.Comminication.Requests;
using MeuLivroDeReceitas.Comminication.Responses;

namespace MeuLivroDeReceitas.Application.UseCases.Login.DoLogin
{
    public interface IDoLoginUseCase
    {
        public Task<ResponseRegisterUserJson> Execute(RequestLoginJson request);
    }
}
