using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Data
{
      public class CarCategory
      {
            [Key]
            public int CategoryID { get; set; }

            [Required]
            public string CategoryName { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            public int AdminC { get; set; }

            [Required]
            public int AdminM { get; set; }

            [Required]
            public DateTimeOffset CreatedUtc { get; set; }
          
            public DateTimeOffset? Modified { get; set; }

      }
}
