using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumberOfWheels { get; set; }
        public string FuelType { get; set; }

    }
}