namespace ControladorDePedidos.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Compras");
        }
    }
}
