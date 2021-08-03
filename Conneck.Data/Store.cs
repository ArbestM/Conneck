using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Data
{
      public class Store
      {
            [Key]
            public int StoreID { get; set; }

            [Required]
            public string StoreName { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            public string Address { get; set; }

            public string Unit { get; set; }

            [Required]
            public string City { get; set; }

            [Required]
            public StateUSA State { get; set; }

            public string Zip { get; set; }

            [Required]
            public DateTimeOffset CreatedUtc { get; set; }
            public DateTimeOffset? Modified { get; set; }
        
           
            [ForeignKey(nameof(Admin))]
            public int AdminID { get; set; }
            public virtual Admin Admin { get; set; }
      }
}
