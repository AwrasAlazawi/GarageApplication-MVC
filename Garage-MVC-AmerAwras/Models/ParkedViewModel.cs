using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.Models
{
    public class ParkedViewModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public DateTime CheckIn { get; set; }


        public ParkedViewModel(ParkedVehicle parkedVehicle)
        {
            Id = parkedVehicle.Id;
            TypeId = parkedVehicle.TypeId;
            RegNumber = parkedVehicle.RegNumber;
            Color = parkedVehicle.Color;
            Brand = parkedVehicle.Brand;
            CheckIn = parkedVehicle.CheckIn;
        }

    }
}