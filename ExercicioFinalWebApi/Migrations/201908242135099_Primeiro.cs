namespace ExercicioFinalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primeiro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        EstadoCivil = c.String(),
                        Identidade = c.Int(nullable: false),
                        Cpf = c.Int(nullable: false),
                        Cnpj = c.Int(nullable: false),
                        NomeFantasia = c.String(),
                        Cep = c.Int(nullable: false),
                        Endereco = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        Telefone = c.Int(nullable: false),
                        Celular = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Usuarios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Clientes");
        }
    }
}
