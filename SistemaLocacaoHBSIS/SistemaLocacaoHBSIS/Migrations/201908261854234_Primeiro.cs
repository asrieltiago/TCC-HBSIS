namespace SistemaLocacaoHBSIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primeiro : DbMigration
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
                        IdLocacao = c.Int(nullable: false, identity: true),
                        IdTipoVeiculo = c.Int(nullable: false),
                        IdRegistro = c.Int(nullable: false),
                        IdColaborador = c.Int(nullable: false),
                        IdPeriodo = c.Int(nullable: false),
                        AceiteTermo = c.Boolean(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdLocacao);
            
            CreateTable(
                "dbo.MarcaAutomovels",
                c => new
                    {
                        IdMarca = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdMarca);
            
            CreateTable(
                "dbo.MarcaMotoes",
                c => new
                    {
                        IdMarca = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdMarca);
            
            CreateTable(
                "dbo.ModeloAutomovels",
                c => new
                    {
                        IdModelo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        IdMarca = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdModelo)
                .ForeignKey("dbo.MarcaAutomovels", t => t.IdMarca, cascadeDelete: true)
                .Index(t => t.IdMarca);
            
            CreateTable(
                "dbo.ModeloMotoes",
                c => new
                    {
                        IdModelo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Marca = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdModelo);
            
            CreateTable(
                "dbo.Periodoes",
                c => new
                    {
                        IdPeriodo = c.Int(nullable: false, identity: true),
                        DataInicial = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPeriodo);
            
            CreateTable(
                "dbo.RegistroVeiculoes",
                c => new
                    {
                        IdRegistro = c.Int(nullable: false, identity: true),
                        Placa = c.String(),
                        Tipo = c.Int(nullable: false),
                        Marca = c.Int(nullable: false),
                        Modelo = c.Int(nullable: false),
                        Cor = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdRegistro);
            
            CreateTable(
                "dbo.TermoLocacaos",
                c => new
                    {
                        IdTermo = c.Int(nullable: false, identity: true),
                        Termo = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdTermo);
            
            CreateTable(
                "dbo.TipoCors",
                c => new
                    {
                        IdCor = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdCor);
            
            CreateTable(
                "dbo.TipoVeiculoes",
                c => new
                    {
                        Automovel = c.Int(nullable: false, identity: true),
                        Moto = c.Int(nullable: false),
                        Bicicleta = c.Int(nullable: false),
                        Patinete = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioAlteracao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Automovel);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModeloAutomovels", "IdMarca", "dbo.MarcaAutomovels");
            DropIndex("dbo.ModeloAutomovels", new[] { "IdMarca" });
            DropTable("dbo.TipoVeiculoes");
            DropTable("dbo.TipoCors");
            DropTable("dbo.TermoLocacaos");
            DropTable("dbo.RegistroVeiculoes");
            DropTable("dbo.Periodoes");
            DropTable("dbo.ModeloMotoes");
            DropTable("dbo.ModeloAutomovels");
            DropTable("dbo.MarcaMotoes");
            DropTable("dbo.MarcaAutomovels");
            DropTable("dbo.Locacaos");
            DropTable("dbo.Colaboradors");
        }
    }
}
