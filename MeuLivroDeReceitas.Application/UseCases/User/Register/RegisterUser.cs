using AutoMapper;
using MeuLivroDeReceitas.Application.Services.AutoMapper;
using MeuLivroDeReceitas.Application.Services.Cryptography;
using MeuLivroDeReceitas.Comminication.Requests;
using MeuLivroDeReceitas.Comminication.Responses;
using MeuLivroDeReceitas.Domain.Repositories;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;

namespace MeuLivroDeReceitas.Application.UseCases.User.Register
{
    public class RegisterUser : IRegisterUserRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PasswordEncrypter _passwordEncrypter;

        public RegisterUser(IUserRepository userRepository,
                            IMapper mapper,
                            PasswordEncrypter passwordEncrypter,
                            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordEncrypter = passwordEncrypter;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {
            // Validar a request
            ValidateRequest(request);

            // Mapear a request para o entidade
            var user = _mapper.Map<Domain.Entities.User>(request);

            user.Password = _passwordEncrypter.Encrypt(request.Password);

            // Salvar no banco de dados
            await _userRepository.AddUser(user);
            await _unitOfWork.Commit();

            return new ResponseRegisterUserJson
            {
                Name = request.Name
            };
        }

        private void ValidateRequest(RequestRegisterUserJson request)
        {            
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var erroMessage = result.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ErrorOnValidationException(erroMessage);
            }
        }
    }
}
