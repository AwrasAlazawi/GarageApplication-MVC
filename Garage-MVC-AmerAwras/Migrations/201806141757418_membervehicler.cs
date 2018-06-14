namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membervehicler : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleType_Id)
                .Index(t => t.VehicleType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParkedVehicleViewModels", "VehicleType_Id", "dbo.VehicleTypes");
            DropIndex("dbo.ParkedVehicleViewModels", new[] { "VehicleType_Id" });
            DropTable("dbo.ParkedVehicleViewModels");
        }
    }
}
