using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
      public class CarDetail
      {
            [Display(Name = "Index")]
            public int CarID { get; set; }

            public string Make { get; set; }

            [Required]
            public string Model { get; set; }

            public string Color { get; set; }


            public string VIN
            {
                  get; set;
            }

            [Display(Name = "License Plate")]
            public string LincesePlate { get; set; }

            [Required]
            public int Year { get; set; }

            
            [Display(Name = "Category")]
            public int CategoryID { get; set; }

            [Display(Name = "Admin ID")]
            public int AdminID { get; set; }

            [Display(Name = "Affiliate Store")]
            public int Store { get; set; }

            [Display(Name = "Created")]
            public DateTimeOffset CreatedUtc { get; set; }

            [Display(Name = "Modified")]
            public DateTimeOffset? ModifiedUtc { get; set; }
      }
}
