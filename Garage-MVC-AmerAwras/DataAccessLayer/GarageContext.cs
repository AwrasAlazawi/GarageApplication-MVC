using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.DataAccessLayer
{
    public class GarageContext : DbContext

    {
        public GarageContext() : base("GarageMVC2")
        {

        }
        public DbSet<Models.ParkedVehicle> Vehicles { get; set; }

        public DbSet<Models.Member> Members { get; set; }
        public DbSet<Models.VehicleType> VehicleTypes { get; set; }
    }
}