namespace ExercicioFinalWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Segundo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "NomeCompleto", c => c.String());
            AddColumn("dbo.Clientes", "Ativo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clientes", "UsuarioCriacao", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "UsuarioAlteracao", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "DataCriacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clientes", "DataAlteracao", c => c.DateTime(nullable: false));
            DropColumn("dbo.Clientes", "Nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Nome", c => c.String());
            DropColumn("dbo.Clientes", "DataAlteracao");
            DropColumn("dbo.Clientes", "DataCriacao");
            DropColumn("dbo.Clientes", "UsuarioAlteracao");
            DropColumn("dbo.Clientes", "UsuarioCriacao");
            DropColumn("dbo.Clientes", "Ativo");
            DropColumn("dbo.Clientes", "NomeCompleto");
        }
    }
}
