namespace SistemaLocacaoHBSIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Segundo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ModeloAutomovels", "IdMarca", "dbo.MarcaAutomovels");
            DropIndex("dbo.ModeloAutomovels", new[] { "IdMarca" });
            DropPrimaryKey("dbo.TipoVeiculoes");
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        IdMarca = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.IdMarca);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        IdModelo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        IdMarca = c.Int(nullable: false),
                        IdTipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdModelo)
                .ForeignKey("dbo.Marcas", t => t.IdMarca, cascadeDelete: true)
                .ForeignKey("dbo.TipoVeiculoes", t => t.IdTipo, cascadeDelete: true)
                .Index(t => t.IdMarca)
                .Index(t => t.IdTipo);
            
            AddColumn("dbo.RegistroVeiculoes", "IdModelo", c => c.Int(nullable: false));
            AddColumn("dbo.RegistroVeiculoes", "IdCor", c => c.Int(nullable: false));
            AddColumn("dbo.TipoVeiculoes", "IdTipo", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TipoVeiculoes", "Tipo", c => c.String());
            AddColumn("dbo.TipoVeiculoes", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddPrimaryKey("dbo.TipoVeiculoes", "IdTipo");
            CreateIndex("dbo.RegistroVeiculoes", "IdModelo");
            CreateIndex("dbo.RegistroVeiculoes", "IdCor");
            AddForeignKey("dbo.RegistroVeiculoes", "IdCor", "dbo.TipoCors", "IdCor", cascadeDelete: true);
            AddForeignKey("dbo.RegistroVeiculoes", "IdModelo", "dbo.Modeloes", "IdModelo", cascadeDelete: true);
            DropColumn("dbo.RegistroVeiculoes", "Tipo");
            DropColumn("dbo.RegistroVeiculoes", "Marca");
            DropColumn("dbo.RegistroVeiculoes", "Modelo");
            DropColumn("dbo.RegistroVeiculoes", "Cor");
            DropColumn("dbo.TipoVeiculoes", "Automovel");
            DropColumn("dbo.TipoVeiculoes", "Moto");
            DropColumn("dbo.TipoVeiculoes", "Bicicleta");
            DropColumn("dbo.TipoVeiculoes", "Patinete");
            DropTable("dbo.MarcaAutomovels");
            DropTable("dbo.MarcaMotoes");
            DropTable("dbo.ModeloAutomovels");
            DropTable("dbo.ModeloMotoes");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.IdModelo);
            
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
            
            AddColumn("dbo.TipoVeiculoes", "Patinete", c => c.Int(nullable: false));
            AddColumn("dbo.TipoVeiculoes", "Bicicleta", c => c.Int(nullable: false));
            AddColumn("dbo.TipoVeiculoes", "Moto", c => c.Int(nullable: false));
            AddColumn("dbo.TipoVeiculoes", "Automovel", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RegistroVeiculoes", "Cor", c => c.Int(nullable: false));
            AddColumn("dbo.RegistroVeiculoes", "Modelo", c => c.Int(nullable: false));
            AddColumn("dbo.RegistroVeiculoes", "Marca", c => c.Int(nullable: false));
            AddColumn("dbo.RegistroVeiculoes", "Tipo", c => c.Int(nullable: false));
            DropForeignKey("dbo.RegistroVeiculoes", "IdModelo", "dbo.Modeloes");
            DropForeignKey("dbo.RegistroVeiculoes", "IdCor", "dbo.TipoCors");
            DropForeignKey("dbo.Modeloes", "IdTipo", "dbo.TipoVeiculoes");
            DropForeignKey("dbo.Modeloes", "IdMarca", "dbo.Marcas");
            DropIndex("dbo.RegistroVeiculoes", new[] { "IdCor" });
            DropIndex("dbo.RegistroVeiculoes", new[] { "IdModelo" });
            DropIndex("dbo.Modeloes", new[] { "IdTipo" });
            DropIndex("dbo.Modeloes", new[] { "IdMarca" });
            DropPrimaryKey("dbo.TipoVeiculoes");
            DropColumn("dbo.TipoVeiculoes", "Valor");
            DropColumn("dbo.TipoVeiculoes", "Tipo");
            DropColumn("dbo.TipoVeiculoes", "IdTipo");
            DropColumn("dbo.RegistroVeiculoes", "IdCor");
            DropColumn("dbo.RegistroVeiculoes", "IdModelo");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Marcas");
            AddPrimaryKey("dbo.TipoVeiculoes", "Automovel");
            CreateIndex("dbo.ModeloAutomovels", "IdMarca");
            AddForeignKey("dbo.ModeloAutomovels", "IdMarca", "dbo.MarcaAutomovels", "IdMarca", cascadeDelete: true);
        }
    }
}
