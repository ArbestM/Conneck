using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Data
{
      public enum Catype
      {
            Hybrid=1,
            Electic,
            Gas
      }
      public class Car
      {
            [Key]
            public int CarID { get; set; }

            [Required]
            public Catype VehiculeType { get; set; }

            [Required]
            public string CarName { get; set; }

            [Required]
            public string Description { get; set; }

            [Required]
            public string Model { get; set; }

            [Required]
            public string Brand { get; set; }

            [Required]
            public string color { get; set; }

            [Required]
            public int VIN { get; set; }

            public string  PlateNumber { get; set; }

            [Required]
            public DateTimeOffset CreatedUtc { get; set; }

            public DateTimeOffset? Modified { get; set; }
      }
}
