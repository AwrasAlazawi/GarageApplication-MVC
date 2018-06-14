namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixolof : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkedVehicles", "Fullname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "Fullname", c => c.String());
        }
    }
}
