using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using FluentAssertions;
using MeuLivroDeReceitas.Application.Services.Cryptography;
using MeuLivroDeReceitas.Application.UseCases.User.Register;
using MeuLivroDeReceitas.Exceptions;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;

namespace UseCases.Test.User.Register
{
    public class RegisterUserTest
    {
        [Fact]
        public async Task Success()
        {
            var request = RequestUserJsonBuilder.Build();
            var useCase = CreateUseCase();

            var result = await useCase.Execute(request);

            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);
        }

        [Fact]
        public async Task Error_Email_Already_Registered()
        {
            var request = RequestUserJsonBuilder.Build();
            var useCase = CreateUseCase(request.Email);

            Func<Task> act = async () => await useCase.Execute(request);
            (await act.Should().ThrowAsync<ErrorOnValidationException>())
                .Where(e => e.ErrorMenssages.Count == 1 &&
                e.ErrorMenssages.Contains(ResourceMessagesExceptions.EMAIL_ALREADY_REGISTERED));
        }

        [Fact]
        public async Task Error_Name_Empty()
        {
            var request = RequestUserJsonBuilder.Build();
            request.Name = string.Empty;

            var useCase = CreateUseCase();

            Func<Task> act = async () => await useCase.Execute(request);
            (await act.Should().ThrowAsync<ErrorOnValidationException>())
                .Where(e => e.ErrorMenssages.Count == 1 &&
                e.ErrorMenssages.Contains(ResourceMessagesExceptions.NAME_EMPTY));
        }

        private RegisterUser CreateUseCase(string? email = null)
        {
            var mapper = MapperBuilder.Build();
            var passwordEncrypter = PasswordEncripterBuilder.Build();
            var userRepositoryBuilder = new UserRepositoryBuilder();
            var unitOfWork = UnitOfWorkBuilder.Build();

            if (string.IsNullOrEmpty(email) == false)
                userRepositoryBuilder.ExistActiveUserWithEmail(email);

            return new RegisterUser(userRepositoryBuilder.Build(), mapper, passwordEncrypter, unitOfWork);
        }
    }
}
