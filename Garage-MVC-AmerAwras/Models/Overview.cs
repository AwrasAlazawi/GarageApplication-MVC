using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Garage_MVC_AmerAwras.Models
{
    public class Overview
    {
        public Overview(string regnr, string color, string brand, string model, int numberOfWheels, DateTime checkIn, VehicleType vehicleType)
        {
            Regnr = regnr;
            Color = color;
            Brand = brand;
            Model = model;
            NumberOfWheels = numberOfWheels;
            VehicleType = vehicleType;

        }
        public string Regnr { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int NumberOfWheels { get; set; }

        [Display(Name = "Arrival time")]
        public DateTime CheckIn { get; set; }
        public VehicleType VehicleType { get; set; }

    }
}

