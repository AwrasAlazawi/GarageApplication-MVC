using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.Models
{
    public class VehicleCheckOut
    {
        public VehicleCheckOut()
        {

        }
        public VehicleCheckOut(int id, string regnr, DateTime checkIn, DateTime nowTime)
        {
            Id = id;
            Regnr = regnr;
            CheckIn = checkIn;
            NowTime = nowTime;
        }

        public int Id { get; set; }
        public string Regnr { get; set; }

        [Display(Name = "Arrival time")]        
        public DateTime CheckIn { get; set; }

        [Display(Name = "Check out time")]        
        public DateTime NowTime { get; set; }
    }

}