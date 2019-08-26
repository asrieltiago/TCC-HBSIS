namespace ExercicioFinalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quinto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Telefone", c => c.String());
            AlterColumn("dbo.Clientes", "Celular", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Celular", c => c.Int(nullable: false));
            AlterColumn("dbo.Clientes", "Telefone", c => c.Int(nullable: false));
        }
    }
}
