namespace ProjetoTCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noturno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Periodos", "Noturno", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Periodos", "Noturno");
        }
    }
}
