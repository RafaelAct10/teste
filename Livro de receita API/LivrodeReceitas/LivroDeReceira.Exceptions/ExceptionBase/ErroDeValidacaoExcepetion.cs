using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceira.Exceptions.ExceptionBase
{
    public class ErroDeValidacaoExcepetion : LivroDeReceitaExcepetion
    {
        public List<string> MensagemDeErro { get; set; }

        public  ErroDeValidacaoExcepetion(List<string> mensagemDeErro) 
        {
           MensagemDeErro = mensagemDeErro;
        }
    }
}
