namespace ProjetoTCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primeiro : DbMigration
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
                        AceiteTermo = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                        Colaborador_Id = c.Int(),
                        Periodo_Id = c.Int(),
                        RegistroVeiculo_Id = c.Int(),
                        TermoLocacao_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaboradores", t => t.Colaborador_Id)
                .ForeignKey("dbo.Periodos", t => t.Periodo_Id)
                .ForeignKey("dbo.RegistroVeiculos", t => t.RegistroVeiculo_Id)
                .ForeignKey("dbo.TermoLocacoes", t => t.TermoLocacao_Id)
                .Index(t => t.Colaborador_Id)
                .Index(t => t.Periodo_Id)
                .Index(t => t.RegistroVeiculo_Id)
                .Index(t => t.TermoLocacao_Id);
            
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
                "dbo.TipoVeiculos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegistroVeiculos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                        Cor_Id = c.Int(),
                        Modelo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoCores", t => t.Cor_Id)
                .ForeignKey("dbo.Modelos", t => t.Modelo_Id)
                .Index(t => t.Cor_Id)
                .Index(t => t.Modelo_Id);
            
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
            DropForeignKey("dbo.Locacoes", "TermoLocacao_Id", "dbo.TermoLocacoes");
            DropForeignKey("dbo.Locacoes", "RegistroVeiculo_Id", "dbo.RegistroVeiculos");
            DropForeignKey("dbo.RegistroVeiculos", "Modelo_Id", "dbo.Modelos");
            DropForeignKey("dbo.Modelos", "Marca_Id", "dbo.Marcas");
            DropForeignKey("dbo.Marcas", "TipoVeiculo_Id", "dbo.TipoVeiculos");
            DropForeignKey("dbo.RegistroVeiculos", "Cor_Id", "dbo.TipoCores");
            DropForeignKey("dbo.Locacoes", "Periodo_Id", "dbo.Periodos");
            DropForeignKey("dbo.Periodos", "TipoVeiculo_Id", "dbo.TipoVeiculos");
            DropForeignKey("dbo.Locacoes", "Colaborador_Id", "dbo.Colaboradores");
            DropIndex("dbo.Marcas", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Modelos", new[] { "Marca_Id" });
            DropIndex("dbo.RegistroVeiculos", new[] { "Modelo_Id" });
            DropIndex("dbo.RegistroVeiculos", new[] { "Cor_Id" });
            DropIndex("dbo.Periodos", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Locacoes", new[] { "TermoLocacao_Id" });
            DropIndex("dbo.Locacoes", new[] { "RegistroVeiculo_Id" });
            DropIndex("dbo.Locacoes", new[] { "Periodo_Id" });
            DropIndex("dbo.Locacoes", new[] { "Colaborador_Id" });
            DropTable("dbo.TermoLocacoes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Modelos");
            DropTable("dbo.TipoCores");
            DropTable("dbo.RegistroVeiculos");
            DropTable("dbo.TipoVeiculos");
            DropTable("dbo.Periodos");
            DropTable("dbo.Locacoes");
            DropTable("dbo.Colaboradores");
        }
    }
}
