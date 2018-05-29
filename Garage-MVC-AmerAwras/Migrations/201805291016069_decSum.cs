namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decSum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "Sum", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "Sum", c => c.Double(nullable: false));
        }
    }
}
