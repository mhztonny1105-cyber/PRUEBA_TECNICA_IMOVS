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
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        Folio = c.String(nullable: false, maxLength: 20),
                        NumeroPago = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaPago = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Folio = c.String(nullable: false, maxLength: 20),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaLiquidacion = c.DateTime(),
                        Estatus = c.String(maxLength: 20),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketDetalles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productos", t => t.ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 500),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
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
