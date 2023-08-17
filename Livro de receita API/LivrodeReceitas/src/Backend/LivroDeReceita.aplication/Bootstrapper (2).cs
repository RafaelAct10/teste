using Google.Protobuf.WellKnownTypes;
using LivroDeReceita.aplication.Serviços.Criptografia;
using LivroDeReceita.aplication.Serviços.Token;
using LivroDeReceita.aplication.UseCases.FazerLogin;
using LivroDeReceita.aplication.UseCases.Usuario.Registrar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LivroDeReceita.aplication
{
    public static class Bootstrapper
    {
        public static void AddAplication(this IServiceCollection services, IConfiguration configuration)
        {
            AdcionarChaveAdcionalSenha(services, configuration);
            AdcionarTokenJWT(services, configuration);
            AdcionarUseCase(services);


            services.AddScoped<IRegistrarUsuarioUseCase,RegistrarUsuarioUseCase>();
        }
    }
     private static void AdcionarChaveAdcionalSenha(IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetRequiredSection("configuracoes:chaveAdicionalSenha");

        services.AddScoped(Option => new EncriptadorDeSenha(section.Value));
    }

    private static void AdcionarTokenJWT(IServiceCollection services, IConfiguration configuration)
    {

        var sectionTempoDeVida = configuration.GetRequiredSection("configuracoes:TempoDeVida");
        var sectionKey = configuration.GetRequiredSection("configuracoes:ChaveDeToken");

        services.AddScoped(Option => new TokenController(int.Parse(sectionTempoDeVida.Value), sectionKey.Value));
    }

    private static void AdcionarUseCase(IRegistrarUsuarioUseCase services)
    {
        services.Addscoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>()
            .addScoped<ILoginUseCase, LoginUseCase>();
    }

}
