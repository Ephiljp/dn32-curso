namespace ControladorDePedidos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Venda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemDaVenda",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Produto_Codigo = c.Int(),
                        Venda_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Produto", t => t.Produto_Codigo)
                .ForeignKey("dbo.Venda", t => t.Venda_Codigo)
                .Index(t => t.Produto_Codigo)
                .Index(t => t.Venda_Codigo);
            
            CreateTable(
                "dbo.Venda",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        DataDeCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDaEfetivacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemDaVenda", "Venda_Codigo", "dbo.Venda");
            DropForeignKey("dbo.ItemDaVenda", "Produto_Codigo", "dbo.Produto");
            DropIndex("dbo.ItemDaVenda", new[] { "Venda_Codigo" });
            DropIndex("dbo.ItemDaVenda", new[] { "Produto_Codigo" });
            DropTable("dbo.Venda");
            DropTable("dbo.ItemDaVenda");
        }
    }
}
