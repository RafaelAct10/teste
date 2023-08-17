using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.Domain.Extension
{
    public static class RepositorioExtension

    {
        public static string GetNomeDataBase(this IConfiguration configurationManager)
        {
            var nomeDataBase = configurationManager.GetConnectionString("NomeDataBase");

            return nomeDataBase;
        }

        public static string GetConexao(this IConfiguration configurationManager)
        {
            var conexao = configurationManager.GetConnectionString("conexao");

            return conexao;
        }

        public static string GetConexaoCompleta(this IConfiguration configurationManager)
        {
            var nomeDataBase = configurationManager.GetNomeDataBase();
            var conexao = configurationManager.GetConexao();

            return $"{conexao}Database = {nomeDataBase}";
        }
    }


}
