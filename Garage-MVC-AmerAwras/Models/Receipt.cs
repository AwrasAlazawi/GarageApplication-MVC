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
        public int TypeId { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime ParkedTime { get; set; }
        public decimal TotalPrice { get; set; }

        public Receipt(int id, string regnum , int typeId, DateTime checkOut, DateTime parkedTime, Decimal totalPrice)
        {
            Id = id;
            RegNum = regnum;
            TypeId = typeId;
            CheckOut = checkOut;
            ParkedTime = parkedTime;
            TotalPrice = totalPrice;

        }
        

        
    }
}