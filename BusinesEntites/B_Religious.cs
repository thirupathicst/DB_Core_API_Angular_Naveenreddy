using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinesEntites
{
    public class B_Religious
    {
        public int ReligiousId { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string Subcaste { get; set; }
        public string Star { get; set; }
        public string Raasi { get; set; }
        public string Gothram { get; set; }
        public string MotherTongue { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
    }
}
