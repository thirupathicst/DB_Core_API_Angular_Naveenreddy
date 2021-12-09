using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBRepository
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }
        public string PhysicalPath { get; set; }
        public string ShortPath { get; set; }
        public int Type { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
