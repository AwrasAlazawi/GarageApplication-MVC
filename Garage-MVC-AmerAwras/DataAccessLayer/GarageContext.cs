using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Garage_MVC_AmerAwras.Models;

namespace Garage_MVC_AmerAwras.DataAccessLayer
{
    public class GarageContext : DbContext
    {

        public GarageContext() : base("GarageConn-MVC")
        {

        }
        public DbSet<ParkedVehicle> ParkedVehicles { get; set; }

    }
}