namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2Olof : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNum = c.String(),
                        CheckOut = c.DateTime(nullable: false),
                        Checkin = c.DateTime(nullable: false),
                        ParkedTime = c.DateTime(nullable: false),
                        TotalTime = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VehicleType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleType_Id)
                .Index(t => t.VehicleType_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipts", "VehicleType_Id", "dbo.VehicleTypes");
            DropIndex("dbo.Receipts", new[] { "VehicleType_Id" });
            DropTable("dbo.Receipts");
        }
    }
}
