namespace ControladorDePedidos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClienteNaVenda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venda", "Cliente_Codigo", c => c.Int());
            CreateIndex("dbo.Venda", "Cliente_Codigo");
            AddForeignKey("dbo.Venda", "Cliente_Codigo", "dbo.Cliente", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Venda", "Cliente_Codigo", "dbo.Cliente");
            DropIndex("dbo.Venda", new[] { "Cliente_Codigo" });
            DropColumn("dbo.Venda", "Cliente_Codigo");
        }
    }
}
