namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class totalPrice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkedVehicles", "TotalTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "TotalTime", c => c.Time(nullable: false, precision: 7));
        }
    }
}
