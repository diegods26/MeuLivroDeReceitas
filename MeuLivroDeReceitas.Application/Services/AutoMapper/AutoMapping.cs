using AutoMapper;
using MeuLivroDeReceitas.Comminication.Requests;
using MeuLivroDeReceitas.Domain.Entities;

namespace MeuLivroDeReceitas.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequesToDomain();
        }

        private void RequesToDomain()
        {
            CreateMap<RequestRegisterUserJson, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
