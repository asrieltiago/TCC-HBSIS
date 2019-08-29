namespace ProjetoTCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class terceiro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locacoes", "Colaborador_Id", "dbo.Colaboradores");
            DropForeignKey("dbo.Locacoes", "Periodo_Id", "dbo.Periodos");
            DropForeignKey("dbo.Locacoes", "TermoLocacao_Id", "dbo.TermoLocacoes");
            DropForeignKey("dbo.Locacoes", "TipoVeiculo_Id", "dbo.TipoVeiculos");
            DropIndex("dbo.Locacoes", new[] { "Colaborador_Id" });
            DropIndex("dbo.Locacoes", new[] { "Periodo_Id" });
            DropIndex("dbo.Locacoes", new[] { "TermoLocacao_Id" });
            DropIndex("dbo.Locacoes", new[] { "TipoVeiculo_Id" });
            AlterColumn("dbo.Locacoes", "Colaborador_Id", c => c.Int());
            AlterColumn("dbo.Locacoes", "Periodo_Id", c => c.Int());
            AlterColumn("dbo.Locacoes", "TermoLocacao_Id", c => c.Int());
            AlterColumn("dbo.Locacoes", "TipoVeiculo_Id", c => c.Int());
            CreateIndex("dbo.Locacoes", "Colaborador_Id");
            CreateIndex("dbo.Locacoes", "Periodo_Id");
            CreateIndex("dbo.Locacoes", "TermoLocacao_Id");
            CreateIndex("dbo.Locacoes", "TipoVeiculo_Id");
            AddForeignKey("dbo.Locacoes", "Colaborador_Id", "dbo.Colaboradores", "Id");
            AddForeignKey("dbo.Locacoes", "Periodo_Id", "dbo.Periodos", "Id");
            AddForeignKey("dbo.Locacoes", "TermoLocacao_Id", "dbo.TermoLocacoes", "Id");
            AddForeignKey("dbo.Locacoes", "TipoVeiculo_Id", "dbo.TipoVeiculos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locacoes", "TipoVeiculo_Id", "dbo.TipoVeiculos");
            DropForeignKey("dbo.Locacoes", "TermoLocacao_Id", "dbo.TermoLocacoes");
            DropForeignKey("dbo.Locacoes", "Periodo_Id", "dbo.Periodos");
            DropForeignKey("dbo.Locacoes", "Colaborador_Id", "dbo.Colaboradores");
            DropIndex("dbo.Locacoes", new[] { "TipoVeiculo_Id" });
            DropIndex("dbo.Locacoes", new[] { "TermoLocacao_Id" });
            DropIndex("dbo.Locacoes", new[] { "Periodo_Id" });
            DropIndex("dbo.Locacoes", new[] { "Colaborador_Id" });
            AlterColumn("dbo.Locacoes", "TipoVeiculo_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacoes", "TermoLocacao_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacoes", "Periodo_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locacoes", "Colaborador_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Locacoes", "TipoVeiculo_Id");
            CreateIndex("dbo.Locacoes", "TermoLocacao_Id");
            CreateIndex("dbo.Locacoes", "Periodo_Id");
            CreateIndex("dbo.Locacoes", "Colaborador_Id");
            AddForeignKey("dbo.Locacoes", "TipoVeiculo_Id", "dbo.TipoVeiculos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locacoes", "TermoLocacao_Id", "dbo.TermoLocacoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locacoes", "Periodo_Id", "dbo.Periodos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locacoes", "Colaborador_Id", "dbo.Colaboradores", "Id", cascadeDelete: true);
        }
    }
}
