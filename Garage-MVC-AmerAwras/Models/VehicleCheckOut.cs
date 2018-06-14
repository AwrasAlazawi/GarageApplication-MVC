using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Garage_MVC_AmerAwras.Models
{
    public class VehicleCheckOut
    {
        public VehicleCheckOut()
        {

        }
        public VehicleCheckOut(int id, string regnr,DateTime checkIn, DateTime nowTime)
        {
            Id = id;
            Regnr = regnr;
           // VehicleType = vehicleType;
            CheckIn = checkIn;
            NowTime = nowTime;
            TimeSpan ts = NowTime - CheckIn;
            TotalTime = $"{Math.Floor(ts.TotalDays)} days, {ts.Hours} hours and {ts.Minutes} minutes.";
            Price = (ts.TotalMinutes + 1) * 2;

        }


        public int Id { get; private set; }
        public string Regnr { get; private set; }
        public string VehicleType { get; private set; }
        [Display(Name = "Time Parked")]
        public DateTime CheckIn { get; private set; }
        [Display]
        public DateTime NowTime { get; private set; }
        public string TotalTime { get; private set; }
        public double Price { get; private set; }
    }
}
