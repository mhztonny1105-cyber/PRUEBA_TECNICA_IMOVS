namespace PRUEBA_TECNICA_IMOVS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablasIniciales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalleTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioTotalFila = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Folio = c.String(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaLiquidacion = c.DateTime(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MontoPendiente = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pagoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        FolioPago = c.String(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaPago = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagoes", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.DetalleTickets", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.DetalleTickets", "ProductoId", "dbo.Productoes");
            DropIndex("dbo.Pagoes", new[] { "TicketId" });
            DropIndex("dbo.DetalleTickets", new[] { "ProductoId" });
            DropIndex("dbo.DetalleTickets", new[] { "TicketId" });
            DropTable("dbo.Pagoes");
            DropTable("dbo.Tickets");
            DropTable("dbo.Productoes");
            DropTable("dbo.DetalleTickets");
        }
    }
}
