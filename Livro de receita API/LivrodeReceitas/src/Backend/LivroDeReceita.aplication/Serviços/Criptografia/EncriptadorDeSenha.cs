using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Cryptography;
using System.Text;

namespace LivroDeReceita.aplication.Serviços.Criptografia
{
    public class EncriptadorDeSenha
    {
        private readonly string _chaveEncriptacao;

        public EncriptadorDeSenha(string chaveEncriptacao)
        {
            _chaveEncriptacao = chaveEncriptacao;
        }

        public  string Criptografar(string senha)
        {
            var senhaComChaveAdicional = $"{senha}{_chaveEncriptacao}";
            var bytes = Encoding.UTF8.GetBytes(senha);
            var Sha512 = SHA512.Create();
            Byte[] hashBytes = Sha512.ComputeHash(bytes);
            return StringBytes(hashBytes);
        }

        private static string StringBytes(byte[] bytes)
        {
           var sb = new StringBuilder();
            foreach(byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
