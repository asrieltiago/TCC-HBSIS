namespace ExercicioFinalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sexto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Cpf", c => c.String());
            AlterColumn("dbo.Clientes", "Cnpj", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Cnpj", c => c.String(maxLength: 18));
            AlterColumn("dbo.Clientes", "Cpf", c => c.String(maxLength: 15));
        }
    }
}
