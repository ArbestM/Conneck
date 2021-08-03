using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
      public class CreateAdmin
      {
            public int AdminID { get; set; }
            [Required]
            [MinLength(3, ErrorMessage = "please enter at least 3 characters.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [MinLength(3, ErrorMessage = "please enter at least 3 characters.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            public string Phone { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }


            [Required]
            public string Address { get; set; }

            [Required]
            public string City { get; set; }

            [Display(Name = "State")]
            public StateUSA State { get; set; }

            [Required]          
            [Display(Name = "Zip Code")]
            public string Zip { get; set; }

            
      }
}
