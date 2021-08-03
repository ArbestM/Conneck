using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Data
{
      public enum Cartype
      {
            Hybrid = 1,
            Electic,
            Gas
      }
      public class Car
      {
          
            [Key]
            public int CarID { get; set; }

            [Required]
            public Cartype CarType { get; set; }

            [Required]
            public string Make { get; set; }

            [Required]
            public string CarM { get; set; }

            [Required]
            public string Color { get; set; }

            [Required]
            public string VIN { get; set; }
                                                 
            [Required]
            public string LicensePlate { get; set; }

            [Required]
            public int Mileage { get; set; }

            [Required]
            public int Rate { get; set; }

            [Required]
            public int Year { get; set; }

            
            [Required]
            public DateTimeOffset CreatedUtc { get; set; }
            public DateTimeOffset? Modified { get; set; }
            
            [ForeignKey(nameof(Store))]
            public int StoreID { get; set; }
            public virtual Store Store { get; set; }

            public int Admin { get; set; }

            [ForeignKey(nameof(CarCategory))]
            public int CategoryID { get; set; }
            public virtual CarCategory CarCategory { get; set; }

      }
}
