using FluentMigrator.Builders.Create.Table;

namespace LivroDeReceita.infra.Migration
{
    public static class VersaoBase
    {
        public static ICreateTableColumnAsTypeSyntax InserirColunasPadrao(ICreateTableWithColumnOrSchemaOrDescriptionSyntax tabela)
        {
            
            return = tabela
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("DataCriacao").AsDateTime().NotNullable();
        }
    }
}
