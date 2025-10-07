namespace PRUEBA_TECNICA_IMOVS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectionModelOrder2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "CustomerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CustomerName", c => c.String());
        }
    }
}
