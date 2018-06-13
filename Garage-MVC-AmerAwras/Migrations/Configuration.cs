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

            Models.Member Olof = new Models.Member() { FirstName = "Olof", LastName = "Karlstrand", Email = "Olof@Lex.com", PhoneNr = "1231231233" };

            context.SaveChanges();

            Models.VehicleType Car = new Models.VehicleType() { TypeId = 1, VehicleTypeName = "Car" };
            context.VehicleType.AddOrUpdate(t => t.VehicleTypeName, Car);
            context.SaveChanges();
            Models.VehicleType Bus = new Models.VehicleType() { TypeId = 2, VehicleTypeName = "Bus" };
            context.VehicleType.AddOrUpdate(t => t.VehicleTypeName, Bus);
            context.SaveChanges();
            Models.VehicleType Motorcycle = new Models.VehicleType() { TypeId = 3, VehicleTypeName = "Motorcycle" };
            context.VehicleType.AddOrUpdate(t => t.VehicleTypeName, Motorcycle);
            context.SaveChanges();
            Models.VehicleType Airplane = new Models.VehicleType() { TypeId = 4, VehicleTypeName = "Airplane" };
            context.VehicleType.AddOrUpdate(t => t.VehicleTypeName, Airplane);
            context.SaveChanges();
            Models.VehicleType Boat = new Models.VehicleType() { TypeId = 5, VehicleTypeName = "Boat" };
            context.VehicleType.AddOrUpdate(t => t.VehicleTypeName, Boat);


            context.SaveChanges();

            Models.ParkedVehicle vehicle = new Models.ParkedVehicle()
            {
                RegNumber = "AAA123",
                Color = "Silver",
                Brand = "BMW",
                Model = "BMW 303",
                NumberOfWheels = 4,
                CheckIn = DateTime.Now,

                MemberId = context.Members.Find().MemberId,
                TypeId = context.VehicleType.Find().TypeId
            };

            Models.ParkedVehicle vehicle2 = new Models.ParkedVehicle()
            {
                RegNumber = "BBB321",
                Color = "Blue",
                Brand = "BMW",
                Model = "BMW X9",
                NumberOfWheels = 4,
                CheckIn = DateTime.Now,
                MemberId = context.Members.Find().MemberId,
                TypeId = context.VehicleType.Find().TypeId
            };

            context.Vehicles.AddOrUpdate(t => t.RegNumber, vehicle);
            context.SaveChanges();



            //            context.Vehicles.AddOrUpdate(
            //          t => new { t.RegNumber, vehicle },

            //      new Models.ParkedVehicle
            //      {
            //          RegNumber = "AAA123",
            //          Color = "Silver",
            //          Brand = "BMW",
            //          Model = "BMW 303",
            //          NumberOfWheels = 4,
            //          CheckIn = DateTime.Now,
            //          MemberId = context.Members.First().MemberId,
            //          TypeId = context.VehicleType.First().TypeId,


            //      },

            //          context.Vehicles.AddOrUpdate(t => t.RegNumber, vehicle);
            //            context.SaveChanges();

            //       new Models.ParkedVehicle
            //       {
            //           RegNumber = "BBB321",
            //           Color = "Blue",           
            //           Brand = "BMW",
            //           Model = "BMW X9",
            //           NumberOfWheels = 4,
            //           CheckIn = DateTime.Now,
            //            MemberId = context.Members.First().MemberId,
            //           TypeId = context.VehicleType.First().TypeId
            //       }, new Models.ParkedVehicle
            //       {
            //           RegNumber = "ASD123",
            //           Color = "Red",         
            //           Brand = "MT",
            //           Model = "MT5",
            //           NumberOfWheels = 2,
            //           CheckIn = DateTime.Now,
            //            MemberId = context.Members.First().MemberId,
            //           TypeId = context.VehicleType.First().TypeId
            //       },
            //       new Models.ParkedVehicle
            //       {
            //           RegNumber = "CCC456",
            //           Color = "Yellow",

            //           Brand = "Boeing",
            //           Model = "747",
            //           NumberOfWheels = 3,
            //           CheckIn = DateTime.Now,
            //            MemberId = context.Members.First().MemberId,
            //           TypeId = context.VehicleType.First().TypeId
            //       },
            //       new Models.ParkedVehicle
            //       {
            //           RegNumber = "VVV987",
            //           Color = "Silver",

            //           Brand = "Volkswagen",
            //           Model = "Typ 2",
            //           NumberOfWheels = 8,
            //           CheckIn = DateTime.Now,
            //            MemberId = context.Members.First().MemberId,
            //           TypeId = context.VehicleType.First().TypeId
            //       },
            //        new Models.ParkedVehicle
            //        {
            //            RegNumber = "SEA666",
            //            Color = "Green",

            //            Brand = "Sea Ray",
            //            Model = "460 Sundance",
            //            NumberOfWheels = 0,
            //            CheckIn = DateTime.Now,
            //            MemberId = context.Members.First().MemberId,
            //            TypeId = context.VehicleType.First().TypeId
            //        }
            //      );
            //        context.SaveChanges();



        }
    }
}

