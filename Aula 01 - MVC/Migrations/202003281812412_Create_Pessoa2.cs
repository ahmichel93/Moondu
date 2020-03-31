namespace Aula_01___MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Pessoa2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoas", "Gosto", c => c.String(unicode: false));
            AddColumn("dbo.Pessoas", "Telefone", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pessoas", "Telefone");
            DropColumn("dbo.Pessoas", "Gosto");
        }
    }
}
