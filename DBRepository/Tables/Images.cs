using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBRepository.Tables
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }
        public string Physicalpath { get; set; }
        public string Shortpath { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonalInfo PersonalInfo { get; set; }
        public DateTime Createddatetime { get; set; }
        public DateTime? Updateddatetime { get; set; }
    }
}
