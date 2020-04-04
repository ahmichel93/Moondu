namespace Aula_01___MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Valor = c.Int(),
                        Quantidade = c.Int(nullable: false),
                        EstaAtivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produtoes");
        }
    }
}
