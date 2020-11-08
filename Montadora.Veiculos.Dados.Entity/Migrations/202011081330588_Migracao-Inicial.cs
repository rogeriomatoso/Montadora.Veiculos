namespace Montadoras.Veiculos.Dados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Montadora",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Nacionalidade = c.String(nullable: false, maxLength: 100),
                        MercadoPaises = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Veiculo",
                c => new
                    {
                        IdVeiculo = c.Long(nullable: false, identity: true),
                        Modelo = c.String(nullable: false, maxLength: 100),
                        ModeloAno = c.Int(name: "Modelo - Ano", nullable: false),
                        NomeMontadora = c.Int(name: "Nome Montadora", nullable: false),
                    })
                .PrimaryKey(t => t.IdVeiculo)
                .ForeignKey("dbo.Montadora", t => t.NomeMontadora, cascadeDelete: true)
                .Index(t => t.NomeMontadora);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veiculo", "Nome Montadora", "dbo.Montadora");
            DropIndex("dbo.Veiculo", new[] { "Nome Montadora" });
            DropTable("dbo.Veiculo");
            DropTable("dbo.Montadora");
        }
    }
}
