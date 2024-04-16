using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBRepository.Tables
{
    public class PartnerInfo
    {
        [Key]
        public int PartnerId { get; set; }
        
        public int Age { get; set; }
        
        [Column(TypeName = "decimal(2,1)")]
        public decimal Height { get; set; }

        [StringLength(30)]
        public string Maritalstatus { get; set; }

        [StringLength(10)]
        public string Complexion { get; set; }

        [StringLength(20)]
        public string Religion { get; set; }

        [StringLength(15)]
        public string Mothertongue { get; set; }

        [StringLength(30)]
        public string Caste { get; set; }

        [StringLength(30)]
        public string Education { get; set; }

        [StringLength(30)]
        public string Occupation { get; set; }

        [StringLength(30)]
        public string Citizen { get; set; }

        [StringLength(30)]
        public string Country { get; set; }

        [StringLength(30)]
        public string State { get; set; }

        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonalInfo PersonalInfo { get; set; }
        [ConcurrencyCheck]
        public DateTime Createddatetime { get; set; }
        public DateTime? Updateddatetime { get; set; }
    }
}