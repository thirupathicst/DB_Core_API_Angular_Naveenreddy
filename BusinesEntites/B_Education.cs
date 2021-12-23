using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinesEntites
{
    public class B_Education
    {
        public int EducationId { get; set; }
        public string School { get; set; }
        public string College { get; set; }
        public string Graducation { get; set; }
        public string Heightqualification { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
    }
}
