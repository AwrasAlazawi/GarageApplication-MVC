using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Garage_MVC_AmerAwras.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Registration Number is required")]
        [StringLength(8)]
        [MinLength(3)]
        [DisplayName("Registration Number")]
        public string RegNumber { get; set; }

        [Required(ErrorMessage = "Please insert a valid color , Maximum 20 letters")]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Please insert a valid name")]
        [StringLength(20)]
        [MinLength(3)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Please insert a valid model")]
        [StringLength(20)]
        public string Model { get; set; }

       [Required(ErrorMessage = "Please insert a valid number of wheels")]
       [DisplayName("Nr Of Wheels")]
       [Range(0, 40, ErrorMessage = "Value must be between 0 to 40")]
        public int NumberOfWheels { get; set; }


        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy h:mm tt}")]
        [DisplayName("Time Checked In")]
        public DateTime CheckIn { get; set; }

        public VehicleType VehicleType { get; set; }


        public int MemberId { get; set; }
        public virtual ICollection<Member> Members { get; set; }


    }

}