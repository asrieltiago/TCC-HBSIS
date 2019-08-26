namespace ExercicioFinalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quarto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Cpf", c => c.String(maxLength: 15));
            AlterColumn("dbo.Clientes", "Cnpj", c => c.String(maxLength: 18));
            AlterColumn("dbo.Clientes", "Cep", c => c.String(maxLength: 9));
            AlterColumn("dbo.Clientes", "Estado", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Estado", c => c.String());
            AlterColumn("dbo.Clientes", "Cep", c => c.String());
            AlterColumn("dbo.Clientes", "Cnpj", c => c.String());
            AlterColumn("dbo.Clientes", "Cpf", c => c.String());
        }
    }
}
