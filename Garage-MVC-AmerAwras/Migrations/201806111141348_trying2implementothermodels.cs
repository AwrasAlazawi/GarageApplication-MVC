namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trying2implementothermodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleReceipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNumber = c.String(),
                        VehicleType = c.String(),
                        CheckIn = c.DateTime(nullable: false),
                        NowTime = c.DateTime(nullable: false),
                        TotalTime = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehicleReceipts");
        }
    }
}
