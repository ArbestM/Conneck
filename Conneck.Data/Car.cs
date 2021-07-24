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

            public Guid OwerId { get; set; }

            [Required]
            public Cartype CarType { get; set; }

            [Required]
            public string CarName { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            public string Model { get; set; }

            [Required]
            public string Brand { get; set; }

            [Required]
            public string Color { get; set; }

            [Required]
            public string VIN { get; set; }

            [Required]
            public string PlateNumber { get; set; }

            [Required]
            public int FBY { get; set; }

            
            [Required]
            public DateTimeOffset CreatedUtc { get; set; }
            public DateTimeOffset? Modified { get; set; }
            
            [ForeignKey(nameof(Store))]
            public int StoreID { get; set; }
            public virtual Store Store { get; set; }

            public virtual Admin Admin { get; set; }

            [ForeignKey(nameof(CarCategory))]
            public int? CategoryID { get; set; }
            public virtual CarCategory CarCategory { get; set; }



      }
}
