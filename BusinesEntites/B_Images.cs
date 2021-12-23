using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinesEntites
{
    public class B_Images
    {
        [JsonIgnore]
        public int PersonId { get; set; }
        public string PhysicalPath { get; set; }
        public string ShortPath { get; set; }
    }
}
