namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        VehicleTypeName = c.String(),
                    })
                .PrimaryKey(t => t.TypeId);
            
            AddColumn("dbo.ParkedVehicles", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ParkedVehicles", "TypeId");
            AddForeignKey("dbo.ParkedVehicles", "TypeId", "dbo.VehicleTypes", "TypeId", cascadeDelete: true);
            DropColumn("dbo.ParkedVehicles", "VehicleType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "VehicleType", c => c.Int(nullable: false));
            DropForeignKey("dbo.ParkedVehicles", "TypeId", "dbo.VehicleTypes");
            DropIndex("dbo.ParkedVehicles", new[] { "TypeId" });
            DropColumn("dbo.ParkedVehicles", "TypeId");
            DropTable("dbo.VehicleTypes");
        }
    }
}
