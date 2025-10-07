namespace PRUEBA_TECNICA_IMOVS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectionOrderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalAmount");
        }
    }
}
