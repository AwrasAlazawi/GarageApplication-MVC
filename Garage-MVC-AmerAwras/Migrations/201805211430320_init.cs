namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNumber = c.String(nullable: false, maxLength: 8),
                        Color = c.String(nullable: false, maxLength: 20),
                        Brand = c.String(nullable: false, maxLength: 20),
                        Model = c.String(nullable: false, maxLength: 20),
                        NumberOfWheels = c.Int(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        VehicleType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParkedVehicles");
        }
    }
}
