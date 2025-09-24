namespace PRUEBA_TECNICA_IMOVS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pagoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        Folio = c.String(nullable: false, maxLength: 20),
                        NumeroPago = c.Int(nullable: false),
                        FechaPago = c.DateTime(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pendiente = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estatus = c.String(nullable: false, maxLength: 20),
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
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagoes", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketDetalles", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketDetalles", "ProductoId", "dbo.Productoes");
            DropIndex("dbo.TicketDetalles", new[] { "ProductoId" });
            DropIndex("dbo.TicketDetalles", new[] { "TicketId" });
            DropIndex("dbo.Pagoes", new[] { "TicketId" });
            DropTable("dbo.Productoes");
            DropTable("dbo.TicketDetalles");
            DropTable("dbo.Tickets");
            DropTable("dbo.Pagoes");
        }
    }
}
