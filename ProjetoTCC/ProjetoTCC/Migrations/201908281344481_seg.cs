namespace ProjetoTCC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TipoVeiculos", "Descricao", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TipoVeiculos", "Descricao", c => c.String(nullable: false));
        }
    }
}
