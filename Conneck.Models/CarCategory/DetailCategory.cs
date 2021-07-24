using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
      public class DetailCategory
      {
            [Display(Name = "Index")]
            public int CategoryID { get; set; }

            [Display(Name = "Name")]
            public string CategoryName { get; set; }

            [Display(Name = "Description")]
            public string Description { get; set; }

            [Display(Name = "Created")]
            public string AdminC { get; set; }

            [Display(Name = "Modified")]
            public string AdminM { get; set; }

            [Display(Name ="Created Time")]
            public DateTimeOffset CreatedUtc { get; set; }

            [Display(Name ="Modified Time")]
            public DateTimeOffset ModifiedUtc { get; set; }
      }
}
