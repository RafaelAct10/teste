using livrodereceira.comunicacao.Request;
using livrodereceira.comunicacao.Response;
using LivroDeReceira.Exceptions.ExceptionBase;
using LivroDeReceita.aplication.Serviços.Criptografia;
using LivroDeReceita.aplication.Serviços.Token;
using LivroDeReceita.Domain.Repositorio;

namespace LivroDeReceita.aplication.UseCases.FazerLogin
{
    public class LoginUseCase : ILoginUseCase
    {

        private readonly IUsuarioReadOnlyRepositorio _usuarioReadOnlyRepositorio;
        private readonly EncriptadorDeSenha _encriptadorDeSenha;
        private readonly TokenController _tokenController;

        public LoginUseCase(IUsuarioReadOnlyRepositorio usuarioReadOnlyRepositorio, EncriptadorDeSenha encriptadorDeSenha, TokenController tokenController) 
        {
            _usuarioReadOnlyRepositorio = usuarioReadOnlyRepositorio;
            _encriptadorDeSenha = encriptadorDeSenha;
            _tokenController = tokenController;

        }

        public async Task<RespostaLoginJson> Execultar(RequisicaologinJson request)
        {
            var usuario = await _usuarioReadOnlyRepositorio.RecuperarPorEmailSenha(request.Email, SenhaCriptografada);

            if (usuario == null)
            {
                throw   new LoginInvalidoException();
            }

            return new RespostaLoginJson
            {
                Nome = usuario.Nome,
                Token = _tokenController.GerarToken(usuario.Email)
            };
        }

    }
}
