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
      public class CarCreate
      {
            [Required]
            [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this fiels.")]          
            public string Make { get; set; }

            [Required]
            [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this fiels.")]
            public string CarM { get; set; }

            [Required]
            [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this fiels.")]
            public string Color { get; set; }

            [Required]
            [MaxLength(17)]
            public string VIN
            {
                  get; set;
            }

            [Display(Name ="Car Type")]
            public Cartype CarType { get; set; }

            [Required]
            public int CategoryID { get; set; }

            [Required]
            [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this fiels.")]
            [Display(Name = "License Plate")]
            public string LicensePlate { get; set; }

            [Required]
            public int Year { get; set; }
    
            [Required]
            public int AdminID { get; set; }

            [Required]
            public int StoreID { get; set; }

            
            public int Mileage { get; set; }

            
            public int Rate { get; set; }
      }
}
