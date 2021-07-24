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

            [Display(Name = "Car Name")]
            public string CarName { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            public string Model { get; set; }

            [Required]
            public string Brand { get; set; }

            public string Color { get; set; }


            public string VIN
            {
                  get; set;
            }

            [Display(Name = "Plate Number")]
            public string PlateNumber { get; set; }

            [Required]
            public int FBY { get; set; }

            
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
