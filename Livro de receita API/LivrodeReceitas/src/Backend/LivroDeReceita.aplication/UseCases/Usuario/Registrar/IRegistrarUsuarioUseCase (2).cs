using livrodereceira.comunicacao.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.aplication.UseCases.Usuario.Registrar
{
    public interface IRegistrarUsuarioUseCase
    {
        Task<RegistrarUsuarioJson> Executar(RegistrarUsuarioJson requisicao);
    }
}
