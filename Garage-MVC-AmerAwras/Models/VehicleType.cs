using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.Models
{
    public class VehicleTypes
    {
        public int TypeId { get; set; }
        public string VehicleName { get; set; }

        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }
    }

}