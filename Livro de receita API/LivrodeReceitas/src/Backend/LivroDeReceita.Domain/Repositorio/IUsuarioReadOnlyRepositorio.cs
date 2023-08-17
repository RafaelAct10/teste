using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.Domain.Repositorio
{
    public interface IUsuarioReadOnlyRepositorio
    {
       Task<bool> ExisteUsuarioComEmail(string email);
        Task RecuperarPorEmailSenha(string email, LivroDeReceita.aplication.Serviços.Criptografia.EncriptadorDeSenha encriptadorDeSenha);
    }
}
