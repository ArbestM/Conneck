using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
      public class CatListItem
      {
            [Display(Name = "Index")]
            public int CategoryID { get; set; }

            [Display(Name = "Category Name")]
            public string CategoryName { get; set; }          

      }
}
