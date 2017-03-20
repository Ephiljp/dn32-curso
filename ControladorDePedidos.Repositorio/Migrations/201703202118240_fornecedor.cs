namespace ControladorDePedidos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fornecedor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            AddColumn("dbo.Produto", "Fornecedor_Codigo", c => c.Int());
            CreateIndex("dbo.Produto", "Fornecedor_Codigo");
            AddForeignKey("dbo.Produto", "Fornecedor_Codigo", "dbo.Fornecedor", "Codigo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "Fornecedor_Codigo", "dbo.Fornecedor");
            DropIndex("dbo.Produto", new[] { "Fornecedor_Codigo" });
            DropColumn("dbo.Produto", "Fornecedor_Codigo");
            DropTable("dbo.Fornecedor");
        }
    }
}
