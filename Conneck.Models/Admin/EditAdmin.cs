using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
      public class EditAdmin
      {
            [Display(Name ="Admin Index")]
            public int AdminID { get; set; }

            [Required]
            [MinLength(3, ErrorMessage = "please enter at least 3 characters.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string FirstName { get; set; }

            [Required]
            [MinLength(3, ErrorMessage = "please enter at least 3 characters.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string LastName { get; set; }

            [Required]
            [MaxLength(17)]
            [DataType(DataType.PhoneNumber)]
            public string Phone { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }


            [Required]
            [MinLength(20, ErrorMessage = "This field can not be empty.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string Address { get; set; }

            [Required]
            [MinLength(20, ErrorMessage = "This field can not be empty.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string City { get; set; }

            [Required]
            [MaxLength(5)]
            [Display(Name = "Zip Code")]
            public string Zip { get; set; }

            [Display(Name = "State")]
            public StateUSA State { get; set; }

            [Display(Name ="Modified")]
            public DateTimeOffset ModifiedUtc { get; set; }
      }
}
