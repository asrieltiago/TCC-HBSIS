namespace ExercicioFinalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Terceiro1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Clientes", "Cep", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Cep", c => c.Int(nullable: false));
            DropColumn("dbo.Clientes", "Discriminator");
        }
    }
}
