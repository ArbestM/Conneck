using Conneck.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Models
{
     public class EditCategory
      {
            [Display(Name ="Index")]
            public int CategoryID { get; set; }

            [Display(Name = "Name")]
            public string CategoryName { get; set; }

            [Display(Name = "Description")]
            public string Description { get; set; }

            [Display(Name = "Modified")]           
            public string AdminM { get; set; }

            public virtual Admin Admin { get; set; }

            [Display(Name ="Modified Time")]
            public DateTimeOffset Modified { get; set; }
      }
}
