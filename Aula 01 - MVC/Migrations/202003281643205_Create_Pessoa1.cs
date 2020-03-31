namespace Aula_01___MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Pessoa1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoas", "CorCabelo", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pessoas", "CorCabelo");
        }
    }
}
