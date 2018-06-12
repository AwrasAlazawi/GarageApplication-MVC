using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.Models
{
    public class ParkedVehicleModel
    {
        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public DateTime CheckIn { get; set; }


        public ParkedVehicleModel(ParkedVehicle parkedVehicle)
        {
            Id = parkedVehicle.Id;
            VehicleType = parkedVehicle.VehicleType;
            RegNumber = parkedVehicle.RegNumber;
            Color = parkedVehicle.Color;
            Brand = parkedVehicle.Brand;
            CheckIn = parkedVehicle.CheckIn;
        }

    }
}