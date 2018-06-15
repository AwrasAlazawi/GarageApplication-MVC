using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.Models
{
    public class Member
    {
        

        [DisplayName("Member")]
        public int MemberId { get; set; }

        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        public VehicleType VehicleType { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Not a valid Mobile number")]
        [DisplayName("Mobile Number")]
        public string PhoneNr { get; set; }

        public virtual IEnumerable<ParkedVehicle> ParkedVehicles { get; set; }


    }
}