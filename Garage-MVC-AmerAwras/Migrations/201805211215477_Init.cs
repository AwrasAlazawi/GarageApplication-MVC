namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkedVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleType = c.String(),
                        RegNumber = c.String(),
                        Color = c.String(),
                        Brand = c.String(),
                        Model = c.String(),
                        NumberOfWheels = c.Int(nullable: false),
                        FuelType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParkedVehicles");
        }
    }
}
