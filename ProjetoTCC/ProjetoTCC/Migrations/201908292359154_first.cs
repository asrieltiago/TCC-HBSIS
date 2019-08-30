namespace ProjetoTCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colaboradores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Pcd = c.Boolean(nullable: false),
                        TrabalhoNoturno = c.Boolean(nullable: false),
                        Carona = c.Boolean(nullable: false),
                        ResideFora = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locacoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Int(nullable: false),
                        Placa = c.String(),
                        AceiteTermo = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                        Colaborador_Id = c.Int(),
                        Cor_Id = c.Int(),
                        Modelo_Id = c.Int(),
                        Periodo_Id = c.Int(),
                        TermoLocacao_Id = c.Int(),
                        TipoVeiculo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaboradores", t => t.Colaborador_Id)
                .ForeignKey("dbo.TipoCores", t => t.Cor_Id)
                .ForeignKey("dbo.Modelos", t => t.Modelo_Id)
                .ForeignKey("dbo.Periodos", t => t.Periodo_Id)
                .ForeignKey("dbo.TermoLocacoes", t => t.TermoLocacao_Id)
                .ForeignKey("dbo.TipoVeiculos", t => t.TipoVeiculo_Id)
                .Index(t => t.Colaborador_Id)
                .Index(t => t.Cor_Id)
                .Index(t => t.Modelo_Id)
                .Index(t => t.Periodo_Id)
                .Index(t => t.TermoLocacao_Id)
                .Index(t => t.TipoVeiculo_Id);
            
            CreateTable(
                "dbo.TipoCores",
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
                "dbo.Modelos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Marca_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.Marca_Id)
                .Index(t => t.Marca_Id);
            
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
                .ForeignKey("dbo.TipoVeiculos", t => t.TipoVeiculo_Id)
                .Index(t => t.TipoVeiculo_Id);
            
            CreateTable(
                "dbo.TipoVeiculos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Periodos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vagas = c.Int(nullable: false),
                        DataInicial = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                        TipoVeiculo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoVeiculos", t => t.TipoVeiculo_Id)
                .Index(t => t.TipoVeiculo_Id);
            
            CreateTable(
                "dbo.TermoLocacoes",
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
            DropForeignKey("dbo.Locacoes", "TipoVeiculo_Id", "dbo.TipoVeiculos");
            DropForeignKey("dbo.Locacoes", "TermoLocacao_Id", "dbo.TermoLocacoes");
            DropForeignKey("dbo.Locacoes", "Periodo_Id", "dbo.Periodos");
            DropForeignKey("dbo.Periodos", "TipoVeiculo_Id", "dbo.TipoVeiculos");
            DropForeignKey("dbo.Locacoes", "Modelo_Id", "dbo.Modelos");
            DropForeignKey("dbo.Modelos", "Marca_Id", "dbo.Marcas");
            DropForeignKey("dbo.Marcas", "TipoVeiculo_Id", "dbo.TipoVeiculos");
            DropForeignKey("dbo.Locacoes", "Cor_Id", "dbo.TipoCores");
            DropForeignKey("dbo.Locacoes", "Colaborador_Id", "dbo.Colaboradores");
            DropIndex("dbo.Periodos", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Marcas", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Modelos", new[] { "Marca_Id" });
            DropIndex("dbo.Locacoes", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Locacoes", new[] { "TermoLocacao_Id" });
            DropIndex("dbo.Locacoes", new[] { "Periodo_Id" });
            DropIndex("dbo.Locacoes", new[] { "Modelo_Id" });
            DropIndex("dbo.Locacoes", new[] { "Cor_Id" });
            DropIndex("dbo.Locacoes", new[] { "Colaborador_Id" });
            DropTable("dbo.TermoLocacoes");
            DropTable("dbo.Periodos");
            DropTable("dbo.TipoVeiculos");
            DropTable("dbo.Marcas");
            DropTable("dbo.Modelos");
            DropTable("dbo.TipoCores");
            DropTable("dbo.Locacoes");
            DropTable("dbo.Colaboradores");
        }
    }
}
