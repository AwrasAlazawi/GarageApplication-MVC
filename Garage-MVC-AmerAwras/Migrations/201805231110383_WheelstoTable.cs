namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WheelstoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "NumberOfWheels", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkedVehicles", "NumberOfWheels");
        }
    }
}
