namespace PRUEBA_TECNICA_IMOVS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pagos",
                c => new
                    {
                        PagoId = c.Int(nullable: false, identity: true),
                        Folio = c.String(nullable: false, maxLength: 20),
                        TicketId = c.Int(nullable: false),
                        NumeroPago = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaPago = c.DateTime(nullable: false),
                        Observaciones = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.PagoId)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Folio = c.String(nullable: false, maxLength: 20),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaLiquidacion = c.DateTime(),
                        MontoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MontoPagado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estatus = c.String(nullable: false, maxLength: 20),
                        Cliente = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.TicketId);
            
            CreateTable(
                "dbo.TicketDetalles",
                c => new
                    {
                        TicketDetalleId = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TicketDetalleId)
                .ForeignKey("dbo.Productos", t => t.ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 100),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagos", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketDetalles", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketDetalles", "ProductoId", "dbo.Productos");
            DropIndex("dbo.TicketDetalles", new[] { "ProductoId" });
            DropIndex("dbo.TicketDetalles", new[] { "TicketId" });
            DropIndex("dbo.Pagos", new[] { "TicketId" });
            DropTable("dbo.Productos");
            DropTable("dbo.TicketDetalles");
            DropTable("dbo.Tickets");
            DropTable("dbo.Pagos");
        }
    }
}
