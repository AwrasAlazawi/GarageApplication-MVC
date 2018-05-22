namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "CheckOut", c => c.DateTime(nullable: false));
            DropColumn("dbo.ParkedVehicles", "NumberOfWheels");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "NumberOfWheels", c => c.Int(nullable: false));
            AlterColumn("dbo.ParkedVehicles", "CheckOut", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
