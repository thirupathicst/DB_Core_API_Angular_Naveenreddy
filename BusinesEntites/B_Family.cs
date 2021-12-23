using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinesEntites
{
    public class B_Family
    {
        public string Fathername { get; set; }
        public string Mothername { get; set; }
        public string Brotheroccupation { get; set; }
        public short Noofbrothers { get; set; }
        public short Noofbrothersunmarrried { get; set; }
        public short Noofbrothersmarrried { get; set; }
        public string Fatheroccupation { get; set; }
        public string Motheroccupation { get; set; }
        public short Noofsisters { get; set; }
        public short Noofsistersmarrried { get; set; }
        public short Noofsistersunmarrried { get; set; }
        public string Sisteroccupation { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
    }
}
