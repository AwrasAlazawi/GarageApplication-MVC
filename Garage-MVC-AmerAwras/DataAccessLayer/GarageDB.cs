using GarageA_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.DataAccessLayer
{
    public class GarageContext : DbContext

    {
        public GarageContext() : base("GarageDB2")
        {

        }
        public DbSet<ParkedVehicle> Vehicles { get; set; }
    }
}