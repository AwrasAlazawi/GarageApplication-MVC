namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vtype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleTypes", "VehicleTypeName", c => c.String(nullable: false, maxLength: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleTypes", "VehicleTypeName", c => c.String());
        }
    }
}
