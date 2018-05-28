namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Price : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "CheckOut", c => c.DateTime());
            AddColumn("dbo.ParkedVehicles", "TotalTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.ParkedVehicles", "Sum", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkedVehicles", "Sum");
            DropColumn("dbo.ParkedVehicles", "TotalTime");
            DropColumn("dbo.ParkedVehicles", "CheckOut");
        }
    }
}
