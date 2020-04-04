namespace Aula_01___MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TreinEcola : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colaboradors",
                c => new
                    {
                        Matricula = c.Int(nullable: false),
                        Nome = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Telefone = c.Int(nullable: false),
                        Gestor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Matricula);
            
            CreateTable(
                "dbo.Treinamentoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Descricao = c.String(unicode: false),
                        Vagas = c.Int(nullable: false),
                        Inicio = c.DateTime(nullable: false, precision: 0),
                        Final = c.DateTime(nullable: false, precision: 0),
                        Local = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Treinamentoes");
            DropTable("dbo.Colaboradors");
        }
    }
}
