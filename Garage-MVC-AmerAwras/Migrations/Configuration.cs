namespace Garage_MVC_AmerAwras.Migrations
{
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

        protected override void Seed(DataAccessLayer.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Vehicles.AddOrUpdate(
            t => new { t.RegNumber },

        new Models.ParkedVehicle
        {
            RegNumber = "AAA123",
            Color = "Silver",
            VehicleType = Models.VehicleType.Car,
            Brand = "BMW",
            Model = "BMW 303",
            NumberOfWheels = 4,
            CheckIn = DateTime.Now
        },

         new Models.ParkedVehicle
         {
             RegNumber = "BBB321",
             Color = "Blue",
             VehicleType = Models.VehicleType.Car,
             Brand = "BMW",
             Model = "BMW X9",
             NumberOfWheels = 4,
             CheckIn = DateTime.Now
         }, new Models.ParkedVehicle
         {
             RegNumber = "ASD123",
             Color = "Red",
             VehicleType = Models.VehicleType.Motorcycle,
             Brand = "MT",
             Model = "MT5",
             NumberOfWheels = 2,
             CheckIn = DateTime.Now
         },
         new Models.ParkedVehicle
         {
             RegNumber = "CCC456",
             Color = "Yellow",
             VehicleType = Models.VehicleType.Airplane,
             Brand = "Boeing",
             Model = "747",
             NumberOfWheels = 3,
             CheckIn = DateTime.Now
         },
         new Models.ParkedVehicle
         {
             RegNumber = "VVV987",
             Color = "Silver",
             VehicleType = Models.VehicleType.Bus,
             Brand = "Volkswagen",
             Model = "Typ 2",
             NumberOfWheels = 8,
             CheckIn = DateTime.Now
         },
          new Models.ParkedVehicle
          {
              RegNumber = "SEA666",
              Color = "Green",
              VehicleType = Models.VehicleType.Boat,
              Brand = "Sea Ray",
              Model = "460 Sundance",
              NumberOfWheels = 0,
              CheckIn = DateTime.Now
          }

        );

        }
    }
}