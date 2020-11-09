namespace Montadoras.Veiculos.Dados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoAltTabVeiculo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Veiculo", name: "Nome Montadora", newName: "Id Montadora");
            RenameIndex(table: "dbo.Veiculo", name: "IX_Nome Montadora", newName: "IX_Id Montadora");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Veiculo", name: "IX_Id Montadora", newName: "IX_Nome Montadora");
            RenameColumn(table: "dbo.Veiculo", name: "Id Montadora", newName: "Nome Montadora");
        }
    }
}
