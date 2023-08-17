using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using MySqlConnector;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlConnection = MySqlConnector.MySqlConnection;
using Dapper;

namespace LivroDeReceita.infra.Migration
{
    public static class DataBase
    {
        public static void CriarDataBase(string conexaoBancoDados, string NomeDataBase)
        {
          using var minhaConexao = new MySqlConnection(conexaoBancoDados);

            var parametros = new DynamicParameters();
            parametros.Add("nome", NomeDataBase);

            var registro = minhaConexao.Query("SELECT * from INFORMATION_SCHEMA.SCHEMA WHERE SCHEMA_NAME = @nome", parametros);

            if (!registro.Any() )
            {
                minhaConexao.Execute($"CREATE DATABASE{NomeDataBase}");
            }

        }

    }
}
