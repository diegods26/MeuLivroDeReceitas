using FluentValidation;
using MeuLivroDeReceitas.Comminication.Requests;
using MeuLivroDeReceitas.Exceptions;

namespace MeuLivroDeReceitas.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ResourceMessagesExceptions.NAME_EMPTY);
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(ResourceMessagesExceptions.EMAIL_EMPTY);
                 When(x => string.IsNullOrEmpty(x.Email) == false, () =>
                 {
                    RuleFor(x => x.Email)
                        .EmailAddress()
                        .WithMessage(ResourceMessagesExceptions.INVALID_EMAIL);
                 });
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(ResourceMessagesExceptions.PASSWORD_EMPTY)
                .MinimumLength(6)
                .WithMessage(ResourceMessagesExceptions.INVALID_PASSWORD);
        }
    }
}
