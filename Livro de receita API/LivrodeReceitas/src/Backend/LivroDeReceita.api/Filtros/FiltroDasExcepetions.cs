using livrodereceira.comunicacao.Response;
using LivroDeReceira.Exceptions;
using LivroDeReceira.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace LivroDeReceita.api.Filtros
{
    public class FiltroDasExcepetions : IExceptionFilter
    {
        void IExceptionFilter.OnException(ExceptionContext context)
        {
            if (context.Exception is LivroDeReceitaExcepetion) 
            {
                TratarMeuLivroDeReceitaException(context);
            }
            else
            {

            }
        }

        private void TratarMeuLivroDeReceitaException(ExceptionContext context)
        {
            if (context.Exception is ErroDeValidacaoExcepetion)
            {
                TratarErroDeValidacaoException(context);
            }
        }

        private void TratarErroDeValidacaoException(ExceptionContext context)
        {
            var erroDeValidacaoException = context.Exception as ErroDeValidacaoExcepetion;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(new RespostaErroJson(erroDeValidacaoException.MensagemDeErro));
        }


        private void LancarErroDesconhecido(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new RespostaErroJson(ResourceMensagemDeErro.ERRO_DESCONHECIDO));
        }
    }
}
