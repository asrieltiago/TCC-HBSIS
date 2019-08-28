namespace ProjetoTCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quarto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacoes", "TipoVeiculo_Id", "dbo.TipoVeiculos");
            DropIndex("dbo.Locacoes", new[] { "TipoVeiculo_Id" });
            AddColumn("dbo.Periodos", "Vagas", c => c.Int(nullable: false));
            AddColumn("dbo.Periodos", "TipoVeiculo_Id", c => c.Int());
            CreateIndex("dbo.Periodos", "TipoVeiculo_Id");
            AddForeignKey("dbo.Periodos", "TipoVeiculo_Id", "dbo.TipoVeiculos", "Id");
            DropColumn("dbo.Locacoes", "TipoVeiculo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locacoes", "TipoVeiculo_Id", c => c.Int());
            DropForeignKey("dbo.Periodos", "TipoVeiculo_Id", "dbo.TipoVeiculos");
            DropIndex("dbo.Periodos", new[] { "TipoVeiculo_Id" });
            DropColumn("dbo.Periodos", "TipoVeiculo_Id");
            DropColumn("dbo.Periodos", "Vagas");
            CreateIndex("dbo.Locacoes", "TipoVeiculo_Id");
            AddForeignKey("dbo.Locacoes", "TipoVeiculo_Id", "dbo.TipoVeiculos", "Id");
        }
    }
}
