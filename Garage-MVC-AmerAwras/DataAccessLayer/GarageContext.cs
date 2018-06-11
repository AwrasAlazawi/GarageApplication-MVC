using Garage_MVC_AmerAwras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.DataAccessLayer
{
    public class GarageContext : DbContext

    {
        public GarageContext() : base("GarageMVC")
        {

        }
        public DbSet<ParkedVehicle> Vehicles { get; set; }

        public DbSet<VehicleReceipt> VehicleReceipts { get; set; }

        public DbSet<VehicleCheckOut> VehicleCheckOuts { get; set; }
    }
}