using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace Garage_MVC_AmerAwras.Models
{
    public class ParkedVehicleViewModel
    {
        public int Id { get; set; }
        [DisplayName("Type of Vehicle")]
        public VehicleType VehicleType { get; set; }
        public string Regnr { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public int NumberOfWheels { get; set; }
        [DisplayName("Owner")]
        public int MemberId { get; set; }
        public int VehicleTypeId { get; set; }

        public IEnumerable<Member> Members { get; set; }
        public IEnumerable<VehicleType> Types { get; set; }



        //Todo Remove!
        [DisplayName("Check in Time")]
        public DateTime CheckIn { get; set; }


        //Todo Remove
        //public ParkedVehicleViewModel(ParkedVehicle parkedVehicle)
        //{
        //    Id = parkedVehicle.Id;
        //    VehicleType = parkedVehicle.VehicleType;
        //    Regnr = parkedVehicle.Regnr;
        //    Color = parkedVehicle.Color;
        //    Brand = parkedVehicle.Brand;
        //    CheckIn = parkedVehicle.CheckIn;

        //}

        //Remove

        public ParkedVehicleViewModel()
        {
        }
    }
}
   