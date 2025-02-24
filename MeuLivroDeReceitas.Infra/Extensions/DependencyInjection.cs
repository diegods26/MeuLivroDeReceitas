using AutoMapper;
using MeuLivroDeReceitas.Application.Services.AutoMapper;
using MeuLivroDeReceitas.Application.Services.Cryptography;
using MeuLivroDeReceitas.Application.UseCases.User.Register;
using MeuLivroDeReceitas.Domain.Repositories;
using MeuLivroDeReceitas.Infra.Context;
using MeuLivroDeReceitas.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeuLivroDeReceitas.Infra.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MeuLivroDeRecitasDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            // Repository
            services.AddScoped<IUserRepository, UserRepository>();

            // Application
            services.AddScoped<IRegisterUserRepository, RegisterUser>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(opt => new PasswordEncrypter());
            services.AddScoped(option => new MapperConfiguration(opt =>
            {
                opt.AddProfile(new AutoMapping());
            }).CreateMapper());

            return services;
        }
    }
}
