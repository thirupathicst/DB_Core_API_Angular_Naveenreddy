using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinesEntites
{
    public class B_Professional
    {
        public int ProfessionalId { get; set; }
        public short Yearofstart { get; set; }
        public string Joblocation { get; set; }
        public int Income { get; set; }
        public string Companydetails { get; set; }
        public string Jobtype { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
    }
}
