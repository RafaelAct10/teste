using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.infra.AcessoRepositorio.Repositorio
{
    public interface IUnidadeDeTrabalho
    {
        Task Commit();
    }
}
