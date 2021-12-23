using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinesEntites
{
    public class B_LoginHistory
    {
        public DateTime Logindatetime { get; set; }
        public string IPaddress { get; set; }
        public string Browsername { get; set; }
        public DateTime? Logoutdatetime { get; set; }
        [JsonIgnore]
        public int LoginId { get; set; }
    }
}
