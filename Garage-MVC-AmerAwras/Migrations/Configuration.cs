namespace Garage_MVC_AmerAwras.Migrations
{
    using GarageA_MVC.Models;
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

            ParkedVehicle vehicle = new ParkedVehicle() { RegNumber = "AAA123", Color = "Silver", VehicleType = Models.VehicleType.Car, Brand = "BMW", Model = "BMW 303", NumberOfWheels = 4, CheckIn = DateTime.Now, CheckOut = DateTime.Now };
            context.Vehicles.AddOrUpdate(t => t.RegNumber, vehicle);
        }
    }
}
