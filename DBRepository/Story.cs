using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBRepository
{
    public class Story
    {
        [Key]
        public int StoryId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public DateTime Marriagedate { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonalInfo PersonalInfo { get; set; }
        public DateTime Createddatetime { get; set; }
        public DateTime? Updateddatetime { get; set; }
    }
}
