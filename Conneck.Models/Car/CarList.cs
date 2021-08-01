using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
      public class CarList
      {
            [Display(Name ="Index")]
            public int CarID { get; set; }
       
            [Display(Name ="Car Name")]
            public string Make { get; set; }

            public Cartype CarType { get; set; }

            [Display(Name = "Category")]
            public int CategoryID { get; set; }

            [Display(Name ="Affiliate Store")]
            public int Store { get; set; }

      }
}
