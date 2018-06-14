namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class searchmember : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ParkedVehicleViewModels", "VehicleType_Id", "dbo.VehicleTypes");
            DropIndex("dbo.ParkedVehicleViewModels", new[] { "VehicleType_Id" });
            DropTable("dbo.ParkedVehicleViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ParkedVehicleViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Regnr = c.String(),
                        Color = c.String(),
                        Brand = c.String(),
                        CheckIn = c.DateTime(nullable: false),
                        VehicleType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ParkedVehicleViewModels", "VehicleType_Id");
            AddForeignKey("dbo.ParkedVehicleViewModels", "VehicleType_Id", "dbo.VehicleTypes", "Id");
        }
    }
}
