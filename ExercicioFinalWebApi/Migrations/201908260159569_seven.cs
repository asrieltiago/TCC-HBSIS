namespace ExercicioFinalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seven : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Identidade", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Identidade", c => c.Int(nullable: false));
        }
    }
}
