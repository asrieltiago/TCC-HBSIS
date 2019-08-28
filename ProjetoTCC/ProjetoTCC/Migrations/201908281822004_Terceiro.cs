namespace ProjetoTCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Terceiro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegistroVeiculos", "Cor_Id", "dbo.TipoCores");
            DropForeignKey("dbo.RegistroVeiculos", "Modelo_Id", "dbo.Modelos");
            DropForeignKey("dbo.Locacoes", "RegistroVeiculo_Id", "dbo.RegistroVeiculos");
            DropIndex("dbo.Locacoes", new[] { "RegistroVeiculo_Id" });
            DropIndex("dbo.RegistroVeiculos", new[] { "Cor_Id" });
            DropIndex("dbo.RegistroVeiculos", new[] { "Modelo_Id" });
            AddColumn("dbo.Locacoes", "Placa", c => c.String());
            AddColumn("dbo.Locacoes", "Cor_Id", c => c.Int());
            AddColumn("dbo.Locacoes", "Modelo_Id", c => c.Int());
            AddColumn("dbo.Locacoes", "TipoVeiculo_Id", c => c.Int());
            CreateIndex("dbo.Locacoes", "Cor_Id");
            CreateIndex("dbo.Locacoes", "Modelo_Id");
            CreateIndex("dbo.Locacoes", "TipoVeiculo_Id");
            AddForeignKey("dbo.Locacoes", "Cor_Id", "dbo.TipoCores", "Id");
            AddForeignKey("dbo.Locacoes", "Modelo_Id", "dbo.Modelos", "Id");
            AddForeignKey("dbo.Locacoes", "TipoVeiculo_Id", "dbo.TipoVeiculos", "Id");
            DropColumn("dbo.Locacoes", "RegistroVeiculo_Id");
            DropTable("dbo.RegistroVeiculos");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Locacoes", "RegistroVeiculo_Id", c => c.Int());
            DropForeignKey("dbo.Locacoes", "TipoVeiculo_Id", "dbo.TipoVeiculos");
            DropForeignKey("dbo.Locacoes", "Modelo_Id", "dbo.Modelos");
            DropForeignKey("dbo.Locacoes", "Cor_Id", "dbo.TipoCores");
            DropIndex("dbo.Locacoes", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Locacoes", new[] { "Modelo_Id" });
            DropIndex("dbo.Locacoes", new[] { "Cor_Id" });
            DropColumn("dbo.Locacoes", "TipoVeiculo_Id");
            DropColumn("dbo.Locacoes", "Modelo_Id");
            DropColumn("dbo.Locacoes", "Cor_Id");
            DropColumn("dbo.Locacoes", "Placa");
            CreateIndex("dbo.RegistroVeiculos", "Modelo_Id");
            CreateIndex("dbo.RegistroVeiculos", "Cor_Id");
            CreateIndex("dbo.Locacoes", "RegistroVeiculo_Id");
            AddForeignKey("dbo.Locacoes", "RegistroVeiculo_Id", "dbo.RegistroVeiculos", "Id");
            AddForeignKey("dbo.RegistroVeiculos", "Modelo_Id", "dbo.Modelos", "Id");
            AddForeignKey("dbo.RegistroVeiculos", "Cor_Id", "dbo.TipoCores", "Id");
        }
    }
}
