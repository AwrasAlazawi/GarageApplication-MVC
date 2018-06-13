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

        protected override void Seed(Garage_MVC_AmerAwras.DataAccessLayer.GarageContext context)
        {
            //  This method will be called after migrating to the latest version.

            Models.Member member = new Models.Member() { FirstName = "Awras", LastName = "Alazawi", Email = "oras.haydar@hotmail.com", PhoneNr = "0760470502" };
            context.Members.AddOrUpdate(m => m.PhoneNr, member);

            context.SaveChanges();

            Models.VehicleType vt = new Models.VehicleType() { TypeId = 1, VehicleTypeName = "Car" };
            context.vehicleTypes.AddOrUpdate(t => t.VehicleTypeName, vt);

            context.SaveChanges();

            Models.ParkedVehicle vehicle = new Models.ParkedVehicle() { RegNumber = "AAA123", Color = "Silver",Brand = "BMW", Model = "BMW 303", NumberOfWheels = 4, CheckIn = DateTime.Now, MemberId = context.Members.First().MemberId, TypeId=context.vehicleTypes.First().TypeId};
            context.Vehicles.AddOrUpdate(t => t.RegNumber, vehicle);
        }
    }
}
