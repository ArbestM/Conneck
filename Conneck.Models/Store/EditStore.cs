using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
      public class EditStore
      {

            public int StoreID { get; set; }

            [MinLength(2, ErrorMessage = "This field can not be empty.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            [Display(Name = "Store Name")]
            public string StoreName { get; set; }


            [MinLength(2, ErrorMessage = "This field can not be empty.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string Description { get; set; }

           
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [MinLength(2, ErrorMessage = "This field can not be empty.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string Address { get; set; }


            [MinLength(2, ErrorMessage = "This field can not be empty.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string Unit { get; set; }


            [MinLength(2, ErrorMessage = "This field can not be empty.")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string City { get; set; }

            [Display(Name ="Modified by")]
            public int AdminID { get; set; }

            public StateUSA State { get; set; }

            [MaxLength(5)]
            [Display(Name = "Zip Code")]
            public string Zip { get; set; }

            [Display(Name = "Modified")]
            public DateTimeOffset ModifiedUtc { get; set; }
      }
}
