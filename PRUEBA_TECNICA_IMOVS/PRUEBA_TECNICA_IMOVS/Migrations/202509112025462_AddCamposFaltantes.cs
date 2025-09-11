namespace PRUEBA_TECNICA_IMOVS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCamposFaltantes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetalleTickets", "PrecioTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "Cliente", c => c.String());
            AddColumn("dbo.Tickets", "PrecioTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Pagoes", "FormaPago", c => c.String());
            AddColumn("dbo.Pagoes", "Folio", c => c.String());
            AddColumn("dbo.Pagoes", "Fecha", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "Folio", c => c.String());
            DropColumn("dbo.DetalleTickets", "PrecioTotalFila");
            DropColumn("dbo.Tickets", "FechaLiquidacion");
            DropColumn("dbo.Tickets", "Total");
            DropColumn("dbo.Pagoes", "FolioPago");
            DropColumn("dbo.Pagoes", "FechaPago");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pagoes", "FechaPago", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pagoes", "FolioPago", c => c.String(nullable: false));
            AddColumn("dbo.Tickets", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Tickets", "FechaLiquidacion", c => c.DateTime());
            AddColumn("dbo.DetalleTickets", "PrecioTotalFila", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Tickets", "Folio", c => c.String(nullable: false));
            DropColumn("dbo.Pagoes", "Fecha");
            DropColumn("dbo.Pagoes", "Folio");
            DropColumn("dbo.Pagoes", "FormaPago");
            DropColumn("dbo.Tickets", "PrecioTotal");
            DropColumn("dbo.Tickets", "Cliente");
            DropColumn("dbo.DetalleTickets", "PrecioTotal");
        }
    }
}
