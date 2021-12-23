using System.Text.Json.Serialization;
using System;

namespace BusinesEntites
{
    public class B_Registration
    {
        public string Filledby { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirmpassword { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
    }
}
