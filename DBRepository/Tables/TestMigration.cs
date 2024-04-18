using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBRepository.Tables
{
    public class TestMigration
    {
        [Key]
        public int TestMId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime Createddatetime { get; set; }
        public DateTime? Updateddatetime { get; set; }
    }
}
