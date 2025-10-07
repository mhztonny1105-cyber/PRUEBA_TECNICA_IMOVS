namespace departamental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
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
                        PrecioUnitario = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Subtotal = c.Decimal(nullable: false, precision: 10, scale: 2),
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
                        Nombre = c.String(nullable: false, maxLength: 150),
                        PrecioUnitario = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Stock = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Folio = c.String(nullable: false, maxLength: 20),
                        FechaDeCreacion = c.DateTime(nullable: false),
                        FechaDeLiquidacion = c.DateTime(),
                        Estado = c.String(nullable: false, maxLength: 20),
                        Total = c.Decimal(nullable: false, precision: 10, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pagoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        NumeroDePago = c.Int(nullable: false),
                        Folio = c.String(nullable: false, maxLength: 20),
                        FechaDePago = c.DateTime(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 10, scale: 2),
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
