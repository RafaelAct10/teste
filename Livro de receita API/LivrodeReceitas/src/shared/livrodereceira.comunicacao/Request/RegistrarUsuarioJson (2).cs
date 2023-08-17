using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livrodereceira.comunicacao.Request
{
    public class RegistrarUsuarioJson
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public object Token { get; set; }
    }
}
