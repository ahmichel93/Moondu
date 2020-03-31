namespace Aula_01___MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Pessoa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        PessoaCpf = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, unicode: false),
                        Email = c.String(unicode: false),
                        Idade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaCpf);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoas");
        }
    }
}
