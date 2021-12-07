using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBRepository
{
    public class Images: DefaultColumnValues
    {
        [Key]
        public int ImageId { get; set; }
        public string PhysicalPath { get; set; }
        public string ShortPath { get; set; }
        public int Type { get; set; }
    }
}
