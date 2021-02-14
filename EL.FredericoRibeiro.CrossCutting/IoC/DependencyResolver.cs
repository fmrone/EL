using Microsoft.Extensions.DependencyInjection;
using EL.FredericoRibeiro.Application;
using EL.FredericoRibeiro.Application.Interfaces;
using EL.FredericoRibeiro.Domain.Repositories;
using EL.FredericoRibeiro.Infrastructure.Repositories;
using System.Diagnostics.CodeAnalysis;
using EL.FredericoRibeiro.Domain.Interfaces;
using EL.FredericoRibeiro.Infrastructure;

namespace EL.FredericoRibeiro.CrossCutting.IoC
{
    [ExcludeFromCodeCoverage]
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterApplications(services);
            RegisterRepositories(services);
        }

        private static void RegisterApplications(IServiceCollection services)
        {
            services.AddScoped<IClienteApplication, ClienteApplication>();
            services.AddScoped<IOperadorApplication, OperadorApplication>();
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();

            services.AddScoped<IUser, User>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IClienteReadOnlyRepository, ClienteRepository>();
            services.AddScoped<IClienteWriteOnlyRepository, ClienteRepository>();

            services.AddScoped<IOperadorReadOnlyRepository, OperadorRepository>();
            services.AddScoped<IOperadorWriteOnlyRepository, OperadorRepository>();

            services.AddScoped<IUsuarioReadOnlyRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioWriteOnlyRepository, UsuarioRepository>();
        }
    }
}