using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBRepository.Tables
{
    public class Audit
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Username { get; set; }
        [Required]
        [MaxLength(128)]
        public string TableName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Action { get; set; }

        public string KeyValues { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}