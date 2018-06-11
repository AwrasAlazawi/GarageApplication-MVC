namespace Garage_MVC_AmerAwras.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moremodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleCheckOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Regnr = c.String(),
                        CheckIn = c.DateTime(nullable: false),
                        NowTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehicleCheckOuts");
        }
    }
}
