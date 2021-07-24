using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conneck.Data
{
      public enum StateUSA
      {
            AL = 1,
            AK,
            AZ,
            AR,
            CA,
            CO,
            CT,
            DE,
            FL,
            GA,
            HI,
            ID,
            IL,
            IN,
            IA,
            KS,
            KY,
            LA,
            ME,
            MD,
            MA,
            MI,
            MN,
            MS,
            MO,
            MT,
            NE,
            NV,
            NH,
            NJ,
            NM,
            NY,
            NC,
            ND,
            OH,
            OK,
            OR,
            PA,
            RI,
            SC,
            SD,
            TN,
            TX,
            UT,
            VT,
            VA,
            WV,
            WI,
            WY
      }
      public class Admin
      {
            [Key]
            public int AdminID { get; set; }

            [Required]
            public Guid OwnerId { get; set; }

            [Required]
            public string FirstName { get; set; }

            [Required]        
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            public string Phone { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            public string Address { get; set; }

            [Required]
            public string City { get; set; }

           [Required]
            public StateUSA State { get; set; }

            [Required]
            public string Zip { get; set; }


            [Required]
            public DateTimeOffset CreatedUtc { get; set; }

            public DateTimeOffset? ModifiedUtc { get; set; }


      }
}
