using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models.Car
{
      public class CarDetail
      {
            [Display(Name ="Car ID")]
            public int CarID { get; set; }

            [Display(Name = "Car Type")]
            public Cartype CarType { get; set; }
           
            [Display(Name = "Car Name")]
         
            public string CarName { get; set; }

            public string Description { get; set; }

            /* [Required]
             [MinLength(6, ErrorMessage = "please enter at least 6 characters.")]
             [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
             public string Model { get; set; } */

            public string Brand { get; set; }

            public string Color { get; set; }
          
            public string VIN { get; set; }

            public int FBY { get; set; }

            [Display(Name = "Plate Number")]
            public string PlateNumber { get; set; }

            [Display(Name ="Created")]
            public DateTimeOffset CreatedUtc { get; set; }

            [Display(Name = "Modified")]
            public DateTimeOffset? ModifiedUtc { get; set; }
      }
}
