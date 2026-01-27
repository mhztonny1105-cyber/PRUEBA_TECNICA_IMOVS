namespace PRUEBA_TECNICA_IMOVS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TicketId = c.Guid(nullable: false),
                        PaymentNumber = c.Int(nullable: false),
                        Folio = c.String(nullable: false, maxLength: 50),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Folio = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        PaidDate = c.DateTime(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PendingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TicketId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 250),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketDetails", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.TicketDetails", new[] { "ProductId" });
            DropIndex("dbo.TicketDetails", new[] { "TicketId" });
            DropIndex("dbo.Payments", new[] { "TicketId" });
            DropTable("dbo.Products");
            DropTable("dbo.TicketDetails");
            DropTable("dbo.Tickets");
            DropTable("dbo.Payments");
        }
    }
}
