using livrodereceira.comunicacao.Request;
using livrodereceira.comunicacao.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.aplication.UseCases.FazerLogin
{
    public interface ILoginUseCase
    {
        Task<RespostaLoginJson> Execultar(RequisicaologinJson request);
    }
}
