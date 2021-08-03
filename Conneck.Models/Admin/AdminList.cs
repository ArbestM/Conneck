
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
      public class AdminList
      {
            [Display(Name = "Index")]
            public int AdminID { get; set; }

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

           
      }
}
