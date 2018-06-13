using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.Models
{

       public class VehicleType
    {
        [Key]
        public int TypeId { get; set; }

        public string VehicleTypeName { get; set; }

        public virtual ICollection<ParkedVehicle> ParkedVehicles { get; set; }

    }

}