namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "MemberId", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "LastName", c => c.String());
            AlterColumn("dbo.Members", "FirstName", c => c.String());
            DropColumn("dbo.ParkedVehicles", "MemberId");
        }
    }
}
