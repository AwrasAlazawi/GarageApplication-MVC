using Garage_MVC_AmerAwras.Models;

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

            var members = new[]{
                new Member() { FirstName = "Awras", LastName = "Alazawi", Email = "oras.haydar@hotmail.com", PhoneNr = "0760470502" },
                new Member () {FirstName ="Olof", LastName ="Karlstrand", Email ="Olof@Mail.com", PhoneNr ="1234567895"},
                new Member () {FirstName ="Amer", LastName ="Durzi", Email ="Amer@Mail.com", PhoneNr ="1234237895"},

        };

            context.Members.AddOrUpdate(m => m.PhoneNr, members);

            context.SaveChanges();

            var types = new[] {
                new VehicleType() {  VehicleTypeName = "Car" },
                new VehicleType() {  VehicleTypeName = "Buss" },
                new VehicleType() { VehicleTypeName = "Motorcycle"},
                new VehicleType() { VehicleTypeName ="Airplane"},
                new VehicleType() {VehicleTypeName="Boat"}
                };

            context.VehicleType.AddOrUpdate(t => t.VehicleTypeName, types[0], types[1], types[2], types[3], types[4]);

            context.SaveChanges();

            var vehicle = new[]
            {
                new ParkedVehicle (){
                Regnr = "AAA123",
                Color = "Silver",
                Brand = "BMW",
                Model = "BMW 303",
                NumberOfWheels = 4,
                CheckIn = DateTime.Now,
                MemberId = members[0].MemberId,              
                VehicleTypeId = types[0].Id,

                },


                new ParkedVehicle()
                {
                Regnr = "BBB321",
                Color = "Purple",
                Brand = "Husqvarna",
                Model = "5000",
                NumberOfWheels = 4,
                CheckIn = DateTime.Now,
                MemberId = members[1].MemberId,
                VehicleTypeId = types[2].Id,

                },

                new ParkedVehicle()
                {
                Regnr = "CCC999",
                Color = "Yellow",
                Brand = "Saab",
                Model = "900",
                NumberOfWheels = 4,
                CheckIn = DateTime.Now,
                MemberId = members[2].MemberId,
                VehicleTypeId = types[1].Id,

                }
            };
        
            context.Vehicles.AddOrUpdate(t => t.Regnr, vehicle);
            context.SaveChanges();            


        }
    }
}

