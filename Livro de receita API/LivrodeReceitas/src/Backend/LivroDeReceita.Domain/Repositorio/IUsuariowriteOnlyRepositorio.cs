using LivroDeReceita.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.Domain.Repositorio
{
    public interface IUsuariowriteOnlyRepositorio
    {
        Task Adicionar(Usuario usuario);
    }
}
