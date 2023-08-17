using AutoMapper;
using livrodereceira.comunicacao.Request;
using LivroDeReceira.Exceptions.ExceptionBase;
using LivroDeReceita.aplication.Serviços.Criptografia;
using LivroDeReceita.aplication.Serviços.Token;
using LivroDeReceita.Domain.Repositorio;
using LivroDeReceita.infra.AcessoRepositorio.Repositorio;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using LivroDeReceira.Exceptions;

namespace LivroDeReceita.aplication.UseCases.Usuario.Registrar
{
    public class RegistrarUsuarioUseCase : IRegistrarUsuarioUseCase
    {

        private readonly IUsuarioReadOnlyRepositorio _usuarioReadOnlyRepositorio;
        private readonly IUsuariowriteOnlyRepositorio _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly EncriptadorDeSenha _encriptadorDeSenha;
        private readonly TokenController _tokenController;

        public RegistrarUsuarioUseCase(IUsuariowriteOnlyRepositorio repositorio, TokenController tokenController, EncriptadorDeSenha encriptadorDeSenha,
        IUnidadeDeTrabalho unidadeDeTrabalho, IUsuarioReadOnlyRepositorio usuarioReadOnlyRepositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _encriptadorDeSenha = encriptadorDeSenha;
            _tokenController = tokenController;
            _usuarioReadOnlyRepositorio = usuarioReadOnlyRepositorio;
        }

        public async Task<RegistrarUsuarioJson> Executar(RegistrarUsuarioJson requisicao)
        {
            await Validar(requisicao);

            var entidade = _mapper.Map<Domain.Entidades.Usuario>(requisicao);
            entidade.Senha = _encriptadorDeSenha.Criptografar(requisicao.Senha);

           await _repositorio.Adicionar(entidade);
            await _unidadeDeTrabalho.Commit();

            var token = _tokenController.GerarToken(entidade.Email);

            return new RegistrarUsuarioJson
            {
                Token  = token
            };

        }

        private async Task Validar (RegistrarUsuarioJson requisicao)
        {
            var validator = new RegsitrarUsuarioValidator();
            var resultado =  validator.Validate(requisicao);

            var existeUsuarioComEmail = await _usuarioReadOnlyRepositorio.ExisteUsuarioComEmail(requisicao.Email);

            if (existeUsuarioComEmail)
            {
                resultado.Errors.Add(new FluentValidation.Results.ValidationFailure("email", ResourceMensagemDeErro.EMAIL_USUARIO_INVALIDO));
            }

            if (resultado.IsValid) 
            {
                var mensagensDeErro = resultado.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErroDeValidacaoExcepetion(mensagensDeErro);
            }
        }

    }
}
