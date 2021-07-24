using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
     public class CarEdit
      {
            [Display(Name ="Index")]
            public int CarID { get; set; }

            [Required]
            [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this fiels.")]
            [Display(Name = "Car Name")]
            public string CarName { get; set; }

            [Required]
            [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this fiels.")]
            public string Description { get; set; }

            [Required]
            [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this fiels.")]
            public string Model { get; set; }


            [Required]
            [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this fiels.")]
            public string Color { get; set; }

            [Display(Name = "Car Type")]
            public Cartype CarType { get; set; }

            [Required]
            [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this fiels.")]
            [Display(Name = "Plate Number")]
            public string PlateNumber { get; set; }


           
            [Display(Name = "Admin ID")]
            public int AdminID { get; set; }

      }
}
