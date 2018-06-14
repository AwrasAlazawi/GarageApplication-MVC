using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Garage_MVC_AmerAwras.Models
{
    public class ParkedVehicleViewModel
    {
        public int Id { get; set; }
        [DisplayName("Type of Vehicle")]
        public VehicleType VehicleType { get; set; }
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public DateTime CheckIn { get; set; }



        public ParkedVehicleViewModel(ParkedVehicle parkedVehicle)
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
   