namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class member : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNr = c.String(nullable: false),
                        ParkedVehicles_Id = c.Int(),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("dbo.ParkedVehicles", t => t.ParkedVehicles_Id)
                .Index(t => t.ParkedVehicles_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "ParkedVehicles_Id", "dbo.ParkedVehicles");
            DropIndex("dbo.Members", new[] { "ParkedVehicles_Id" });
            DropTable("dbo.Members");
        }
    }
}
