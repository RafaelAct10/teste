using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string  Nome { get; set ;}
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
    }
}
