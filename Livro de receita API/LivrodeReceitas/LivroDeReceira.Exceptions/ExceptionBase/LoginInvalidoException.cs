using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceira.Exceptions.ExceptionBase
{
    public class LoginInvalidoException : LivroDeReceitaExcepetion
    {
        public LoginInvalidoException() : base(ResourceMensagemDeErro.Login_invalido) 
        {

        } 
    }
}
