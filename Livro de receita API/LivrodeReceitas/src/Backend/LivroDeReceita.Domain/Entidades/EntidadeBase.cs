using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.Domain.Entidades
{
    public class EntidadeBase
    {
        public long id { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
