namespace Garage_MVC_AmerAwras.Migrations
{
    using Garage_MVC_AmerAwras.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage_MVC_AmerAwras.DataAccessLayer.GarageContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage_MVC_AmerAwras.DataAccessLayer.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            ParkedVehicle vehicle = new ParkedVehicle() { VehicleType = "Car", RegNumber = "WFC456", Color = "Red", Brand = "Volvo", Model = "V210", NumberOfWheels = 4, FuelType = "Gaz" };
            context.ParkedVehicles.AddOrUpdate(t => t.VehicleType, vehicle);
            
        }
    }
}
