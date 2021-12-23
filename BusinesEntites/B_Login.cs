using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinesEntites
{
    public class B_Login
    {
        public string Emailid { get; set; }
        public string Password { get; set; }
        public bool ActiveStatus { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
    }
}
