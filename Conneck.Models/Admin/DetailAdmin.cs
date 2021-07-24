using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
      public class DetailAdmin
      {
            [Display(Name ="Admin ID")]
            public int AdminID { get; set; }

            [Display(Name ="First Name")]
            public string FirstName { get; set; }

            [Display(Name ="Last Name")]
            public string LastName { get; set; }

            public string Phone { get; set; }

            public string Email { get; set; }

            public string Address { get; set; }

            public string City { get; set; }

            [Display(Name = "Zip Code")]
            public string Zip { get; set; }

            public StateUSA State { get; set; }

            [Display(Name ="Affliate Store")]
            public string Store { get; set; }

            [Display(Name = "Created")]
            public DateTimeOffset CreatedUtc { get; set; }

            [Display(Name = "Modified")]
            public DateTimeOffset ModifiedUtc { get; set; }

      }
}
