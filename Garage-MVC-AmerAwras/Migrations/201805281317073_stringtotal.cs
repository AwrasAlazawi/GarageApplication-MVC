namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringtotal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "TotalTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "TotalTime", c => c.Time(precision: 7));
        }
    }
}
