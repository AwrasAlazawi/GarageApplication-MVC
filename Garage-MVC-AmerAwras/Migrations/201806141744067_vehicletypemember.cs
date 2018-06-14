namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicletypemember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "VehicleType_Id", c => c.Int());
            CreateIndex("dbo.Members", "VehicleType_Id");
            AddForeignKey("dbo.Members", "VehicleType_Id", "dbo.VehicleTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "VehicleType_Id", "dbo.VehicleTypes");
            DropIndex("dbo.Members", new[] { "VehicleType_Id" });
            DropColumn("dbo.Members", "VehicleType_Id");
        }
    }
}
