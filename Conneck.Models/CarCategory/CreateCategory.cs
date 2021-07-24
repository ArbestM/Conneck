using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
     public class CreateCategory
      {      
            [Display(Name ="Category Name")]
            public string CategoryName { get; set; }

            [Display(Name ="Description")]
            public string Description { get; set; }

            [Display(Name ="Created")]
            public string AdminC { get; set; }

            public virtual Admin Admin { get; set; }

      }
}
