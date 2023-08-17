using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceita.infra.Migration.Versoes
{
    [Migration((long)NumeroVersoes.CriarTabelaUsuario,"Cria tabela usuario")]
    public class Versao001 : MigrationBase
    {
        public override void Down()
        {
                        
        }

        public override void Up()
        {
            var tabela = Create.Table("usuario");
            VersaoBase.InserirColunasPadrao(tabela);

            tabela.WithColumn("nome").AsString(100).NotNullable();
            tabela.WithColumn("Email").AsString().NotNullable();
            tabela.WithColumn("senha").AsString(2000).NotNullable();
            tabela.WithColumn("Telefone").AsString(14).NotNullable();
                
        }
    }
}
