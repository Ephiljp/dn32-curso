namespace ControladorDePedidos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Compra02 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ItemDaCompra", new[] { "produto_Codigo" });
            CreateIndex("dbo.ItemDaCompra", "Produto_Codigo");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ItemDaCompra", new[] { "Produto_Codigo" });
            CreateIndex("dbo.ItemDaCompra", "produto_Codigo");
        }
    }
}
