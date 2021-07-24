using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
      public class StoreDetail
      {
            [Display(Name = "Index")]
            public int StoreID { get; set; }

            
            [Display(Name = "Name")]
            public string StoreName { get; set; }

            public string Description { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            public string Address { get; set; }

            public string Unit { get; set; }

            public string City { get; set; }
         
            public StateUSA State { get; set; }

            [Display(Name ="Owner")]
            public int AdminID { get; set; }

            [Display(Name = "Zip Code")]
            public string Zip { get; set; }

            [Display(Name ="Created")]
            public DateTimeOffset CreatedUtc { get; set; }

            [Display(Name ="Modified")]
            public DateTimeOffset? Modified { get; set; }

      }
}
