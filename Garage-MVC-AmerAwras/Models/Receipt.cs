using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.Models
{
    public class Receipt
    {

        public int Id { get; set; }
        public string RegNum { get; set; }
        public VehicleType VehicleType { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime ParkedTime { get; set; }
        public decimal TotalPrice { get; set; }

        public Receipt(int id, string regnum , VehicleType vehicleType, DateTime checkOut, DateTime parkedTime, Decimal totalPrice)
        {
            Id = id;
            RegNum = regnum;
            VehicleType = vehicleType;
            CheckOut = checkOut;
            ParkedTime = parkedTime;
            TotalPrice = totalPrice;

        }
        

        
    }
}