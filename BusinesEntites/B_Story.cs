﻿using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinesEntites
{
    public class B_Story
    {
        [JsonIgnore]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime MarriageDate { get; set; }
    }
}
