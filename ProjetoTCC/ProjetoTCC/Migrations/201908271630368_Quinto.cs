namespace ProjetoTCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quinto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colaboradors",
                c => new
                    {
                        IdColaborador = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Pcd = c.Boolean(nullable: false),
                        TrabalhoNoturno = c.Boolean(nullable: false),
                        Carona = c.Boolean(nullable: false),
                        Idoso = c.Boolean(nullable: false),
                        ResideFora = c.Boolean(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Idade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdColaborador);
            
            CreateTable(
                "dbo.Locacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTipo = c.Int(nullable: false),
                        IdRegistroVeiculo = c.Int(nullable: false),
                        IdColaborador = c.Int(nullable: false),
                        IdPeriodo = c.Int(nullable: false),
                        IdTermo = c.Int(nullable: false),
                        AceiteTermo = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaboradors", t => t.IdColaborador, cascadeDelete: true)
                .ForeignKey("dbo.Periodoes", t => t.IdPeriodo, cascadeDelete: true)
                .ForeignKey("dbo.RegistroVeiculoes", t => t.IdRegistroVeiculo, cascadeDelete: true)
                .ForeignKey("dbo.TermoLocacaos", t => t.IdTermo, cascadeDelete: true)
                .ForeignKey("dbo.TipoVeiculoes", t => t.IdTipo, cascadeDelete: true)
                .Index(t => t.IdTipo)
                .Index(t => t.IdRegistroVeiculo)
                .Index(t => t.IdColaborador)
                .Index(t => t.IdPeriodo)
                .Index(t => t.IdTermo);
            
            CreateTable(
                "dbo.Periodoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataInicial = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegistroVeiculoes",
                c => new
                    {
                        IdRegistro = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        IdModelo = c.Int(nullable: false),
                        IdCor = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdRegistro)
                .ForeignKey("dbo.TipoCors", t => t.IdCor, cascadeDelete: true)
                .ForeignKey("dbo.Modeloes", t => t.IdModelo, cascadeDelete: true)
                .Index(t => t.IdModelo)
                .Index(t => t.IdCor);
            
            CreateTable(
                "dbo.TipoCors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        IdMarca = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.IdMarca, cascadeDelete: true)
                .Index(t => t.IdMarca);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(),
                        TipoVeiculo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoVeiculoes", t => t.TipoVeiculo_Id)
                .Index(t => t.TipoVeiculo_Id);
            
            CreateTable(
                "dbo.TipoVeiculoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TermoLocacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Termo = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacaos", "IdTipo", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Locacaos", "IdTermo", "dbo.TermoLocacaos");
            DropForeignKey("dbo.Locacaos", "IdRegistroVeiculo", "dbo.RegistroVeiculoes");
            DropForeignKey("dbo.RegistroVeiculoes", "IdModelo", "dbo.Modeloes");
            DropForeignKey("dbo.Modeloes", "IdMarca", "dbo.Marcas");
            DropForeignKey("dbo.Marcas", "TipoVeiculo_Id", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.RegistroVeiculoes", "IdCor", "dbo.TipoCors");
            DropForeignKey("dbo.Locacaos", "IdPeriodo", "dbo.Periodoes");
            DropForeignKey("dbo.Locacaos", "IdColaborador", "dbo.Colaboradors");
            DropIndex("dbo.Marcas", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Modeloes", new[] { "IdMarca" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "IdCor" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "IdModelo" });
            DropIndex("dbo.Locacaos", new[] { "IdTermo" });
            DropIndex("dbo.Locacaos", new[] { "IdPeriodo" });
            DropIndex("dbo.Locacaos", new[] { "IdColaborador" });
            DropIndex("dbo.Locacaos", new[] { "IdRegistroVeiculo" });
            DropIndex("dbo.Locacaos", new[] { "IdTipo" });
            DropTable("dbo.TermoLocacaos");
            DropTable("dbo.TipoVeiculoes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Modeloes");
            DropTable("dbo.TipoCors");
            DropTable("dbo.RegistroVeiculoes");
            DropTable("dbo.Periodoes");
            DropTable("dbo.Locacaos");
            DropTable("dbo.Colaboradors");
        }
    }
}
