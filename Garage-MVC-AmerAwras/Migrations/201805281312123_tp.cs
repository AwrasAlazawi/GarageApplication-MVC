namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "TotalTime", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkedVehicles", "TotalTime");
        }
    }
}
