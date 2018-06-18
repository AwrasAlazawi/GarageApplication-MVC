namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkfunction : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ParkedVehicles", "Color", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ParkedVehicles", "Color", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
