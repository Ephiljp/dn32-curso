namespace ControladorDePedidos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        DataDeCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDaEfetivacao = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDoRecebimento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        QuantidadeDeProdutos = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.ItemDaCompra",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        produto_Codigo = c.Int(),
                        Compra_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Produto", t => t.produto_Codigo)
                .ForeignKey("dbo.Compra", t => t.Compra_Codigo)
                .Index(t => t.produto_Codigo)
                .Index(t => t.Compra_Codigo);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        ValorDeCompra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorDeVenda = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantidadeEmEstoque = c.Int(nullable: false),
                        QuantidadeMinimaEmEstoque = c.Int(nullable: false),
                        QuantidadeDesejavelEmEstoque = c.Int(nullable: false),
                        Marca_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Marca", t => t.Marca_Codigo)
                .Index(t => t.Marca_Codigo);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Administrador = c.Boolean(nullable: false),
                        Clientes = c.Boolean(nullable: false),
                        Produtos = c.Boolean(nullable: false),
                        Vendas = c.Boolean(nullable: false),
                        Fornecedores = c.Boolean(nullable: false),
                        Compras = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemDaCompra", "Compra_Codigo", "dbo.Compra");
            DropForeignKey("dbo.ItemDaCompra", "produto_Codigo", "dbo.Produto");
            DropForeignKey("dbo.Produto", "Marca_Codigo", "dbo.Marca");
            DropIndex("dbo.Produto", new[] { "Marca_Codigo" });
            DropIndex("dbo.ItemDaCompra", new[] { "Compra_Codigo" });
            DropIndex("dbo.ItemDaCompra", new[] { "produto_Codigo" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Marca");
            DropTable("dbo.Produto");
            DropTable("dbo.ItemDaCompra");
            DropTable("dbo.Compra");
            DropTable("dbo.Cliente");
        }
    }
}
