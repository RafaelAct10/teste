using FluentMigrator.Runner;
using LivroDeReceita.Domain.Extension;
using LivroDeReceita.Domain.Repositorio;
using LivroDeReceita.infra.AcessoRepositorio;
using LivroDeReceita.infra.AcessoRepositorio.Repositorio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace LivroDeReceita.infra
{
    public static class Bootstrapper
    {
        public static void AddRepositorio(this IServiceCollection services, IConfiguration configurationManager)
        {
            AddFluentMigrator(services, configurationManager);

            AddContexto(services, configurationManager);
            AddUnidadeDeTrabalho(services);
            AddRepositorio(services);

        }

        private static void AddContexto(IServiceCollection services,  IConfiguration cconfigurationManager)
        {

            var versaoServidor = new MySqlServerVersion(new Version(8,0,26));
            var connextionString = cconfigurationManager.GetConexaoCompleta();

            services.AddDbContext<LivroDeReceitaContext>(dbContextoOpcoes =>
            {
                dbContextoOpcoes.UseMySql(connextionString, versaoServidor);
            });
        }



        private static void AddUnidadeDeTrabalho(IServiceCollection services)
        {
            services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
        }

        private static void AddRepositorio(IServiceCollection services)
        {
            services.AddScoped<IUsuarioReadOnlyRepositorio, UsuarioRepositorio>()
                   .AddScoped<IUsuariowriteOnlyRepositorio, UsuarioRepositorio>();
        }
        private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManager)
        {
            services.AddFluentMigratorCore().ConfigureRunner(c =>
                c.AddMySql5()
                .WithGlobalConnectionString(configurationManager.GetConexaoCompleta()).ScanIn(Assembly.Load("LivroDeReceita.Infra")).For.All());
        }
    }
}
