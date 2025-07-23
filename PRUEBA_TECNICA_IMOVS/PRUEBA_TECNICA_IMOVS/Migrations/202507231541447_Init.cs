namespace PRUEBA_TECNICA_IMOVS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CotizacionDetalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnidadesCotizadas = c.Int(nullable: false),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CotizacionId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cotizacion", t => t.CotizacionId)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .Index(t => t.CotizacionId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Cotizacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaCotizacion = c.DateTime(nullable: false),
                        TotalCotizacion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IVA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstadoVenta = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockDisponible = c.Int(nullable: false),
                        Estatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CotizacionDetalle", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.CotizacionDetalle", "CotizacionId", "dbo.Cotizacion");
            DropIndex("dbo.CotizacionDetalle", new[] { "ProductoId" });
            DropIndex("dbo.CotizacionDetalle", new[] { "CotizacionId" });
            DropTable("dbo.Producto");
            DropTable("dbo.Cotizacion");
            DropTable("dbo.CotizacionDetalle");
        }
    }
}
