namespace Montadoras.Veiculos.Dados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoCNPJ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Montadora", "CNPJ", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Montadora", "CNPJ");
        }
    }
}
