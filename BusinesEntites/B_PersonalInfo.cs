﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace BusinesEntites
{
    public class B_PersonalInfo
    {
        [JsonIgnore]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string Timeofbirth { get; set; }
        public decimal Height { get; set; }
        public string Complexion { get; set; }
        public long Mobileno { get; set; }
        public string Yourself { get; set; }
        public string Generatedby { get; set; }
        public string Profileid { get; set; }
        public string Maritalstatus { get; set; }
        public string Placeofbirth { get; set; }
    }
}
