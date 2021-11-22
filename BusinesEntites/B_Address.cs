using System;
using System.Collections.Generic;
using System.Text;

namespace BusinesEntites
{
    public class B_Address
    {
        public int AddressId { get; set; }
        public string PermanentAddress { get; set; }
        public string ContactAddress { get; set; }
        public string Visa { get; set; }
        public int Pincode { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Settled { get; set; }
        public string Native { get; set; }
        public int PersonId { get; set; }
    }
}
