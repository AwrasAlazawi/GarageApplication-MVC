namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upsys : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkedVehicles", "CheckOut");
            DropColumn("dbo.ParkedVehicles", "TotalTime");
            DropColumn("dbo.ParkedVehicles", "Sum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "Sum", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ParkedVehicles", "TotalTime", c => c.String());
            AddColumn("dbo.ParkedVehicles", "CheckOut", c => c.DateTime());
        }
    }
}
