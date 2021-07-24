using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
      public class StoreList
      {
            [Display(Name="Index")]
            public int StoreID { get; set; }

            public string Name { get; set; }
      }
}
