using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models.Car
{
      public class CarListItem
      {
            [Display(Name ="Car Index")]
            public int CarID { get; set; }

            [Required]
            [Display(Name = "Car Type")]
            public Cartype CarType { get; set; }

            [Required]
            [MinLength(2, ErrorMessage = "please enter at least 2 characters.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string CarName { get; set; }

            [Required]
            [Display(Name = "Created")]
            public DateTimeOffset CreatedUtc { get; set; }
      }
}
