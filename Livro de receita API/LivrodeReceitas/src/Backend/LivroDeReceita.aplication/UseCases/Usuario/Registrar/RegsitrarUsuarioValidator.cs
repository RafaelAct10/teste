using FluentValidation;
using livrodereceira.comunicacao.Request;
using LivroDeReceira.Exceptions;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LivroDeReceita.aplication.UseCases.Usuario.Registrar
{
    public class RegsitrarUsuarioValidator : AbstractValidator<RegistrarUsuarioJson>
    {
        public RegsitrarUsuarioValidator() 
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage(ResourceMensagemDeErro.NOME_USUARIO_EMBRANCO);
            RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceMensagemDeErro.EMAIL_USUARIO_EMBRANCO);
            RuleFor(c => c.Senha).NotEmpty().WithMessage(ResourceMensagemDeErro.SENHA_USUARIO_EMBRANCO);
            RuleFor(c => c.Telefone).NotEmpty().WithMessage(ResourceMensagemDeErro.TELEFONE_USUARIO_EMBRANCO);
            RuleFor(c => c.Senha.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMensagemDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES);
            When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
            {
                RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMensagemDeErro.EMAIL_USUARIO_EMBRANCO);
            });
            When(c => !string.IsNullOrWhiteSpace(c.Senha), () =>
            {
                RuleFor(c => c.Senha.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMensagemDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES);
            });
            When(c => !string.IsNullOrWhiteSpace(c.Telefone), () =>
            {
                RuleFor(c => c.Telefone).Custom((telefone, Contexto) => 
                {
                    string padraoTelefone = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
                   var isMatch = Regex.IsMatch(telefone, padraoTelefone);
                    if (!isMatch) 
                    {
                        Contexto.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(telefone),ResourceMensagemDeErro.TELEFONE_USUARIO_INVALIDO));
                    }
                });
            });
        }
    }
}
