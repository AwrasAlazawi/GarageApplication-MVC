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

        [Required(ErrorMessage = "Registration Number should include at least three letters and maximum 5 numbers")]
        [StringLength(8)]
        [DisplayName("Regestation Number")]
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
        //[DisplayFormat(NullDisplayText = "Undefined")]
       [DisplayName("Nr Of Wheels")]
       [Range(0, 40, ErrorMessage = "Value must be between 0 to 40")]
        public int NumberOfWheels { get; set; }


        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DisplayFormat(NullDisplayText = "Undefined")]
        //  [DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss}")]
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm\\  - dd/MM/yyyy}", ApplyFormatInEditMode = true)]
       [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy h:mm tt}")]
        [DisplayName("Time Checked In")]
        public DateTime CheckIn { get; set; }

        // [DisplayFormat(DataFormatString = "{0:hh\\:mm\\  - dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy h:mm tt}")]
        [DisplayName("Time Checked Out")]
        //[DefaultValue("2018-05-23 13:00:00")]
        public DateTime? CheckOut { get; set; }


        // [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy h:mm tt}")]
        [DisplayFormat(DataFormatString = "{0:HH}")]
        [DisplayName("Total parking time")]
        public string TotalTime { get; set; }

        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayFormat (DataFormatString = "{0:N0}")]
        [DisplayName("Price Per Hour")]
        public int PricePerHour { get { return 25; } }


        [DataType(DataType.Currency)]
       // [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Total Price:")]
        public double Sum { get; set; }

        public VehicleType VehicleType { get; set; }


    }

}