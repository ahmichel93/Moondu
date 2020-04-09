namespace Aula_01___MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoTreinamento : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Treinamentoes");
            AlterColumn("dbo.Treinamentoes", "Codigo", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Treinamentoes", "Codigo");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Treinamentoes");
            AlterColumn("dbo.Treinamentoes", "Codigo", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Treinamentoes", "Codigo");
        }
    }
}
