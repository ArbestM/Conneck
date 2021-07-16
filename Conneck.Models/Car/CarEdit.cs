using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models.Car
{
      public class CarEdit
      {
            [Display(Name = "Car ID")]
            public int CarID { get; set; }

            [Required]
            [Display(Name = "Car Type : ")]
            public Cartype CarType { get; set; }

            [Required]
            [Display(Name = "Car Name : ")]
            [MinLength(2, ErrorMessage = "please enter at least 2 characters.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string CarName { get; set; }

            [Required]
            [MinLength(2, ErrorMessage = "please enter at least 2 characters.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string Description { get; set; }

            /* [Required]
             [MinLength(6, ErrorMessage = "please enter at least 6 characters.")]
             [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
             public string Model { get; set; } */

            [Required]
            [MinLength(2, ErrorMessage = "please enter at least 4 characters.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string Brand { get; set; }

            [Required]
            [MinLength(2, ErrorMessage = "please enter at least 3 characters.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string Color { get; set; }

            [MinLength(2, ErrorMessage = "please enter at least 3 characters.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            [Display(Name = "Plate Number : ")]
            public string PlateNumber { get; set; }
      }
}
