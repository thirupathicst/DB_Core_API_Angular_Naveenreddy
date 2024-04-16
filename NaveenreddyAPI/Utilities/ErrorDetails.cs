using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace NaveenreddyAPI.Utilities
{
    public class ErrorDetails
    {
        public int statuscode { get; set; }
        public string message { get; set; }
        public ErrorDetails(int statuscode, string message)
        {
            this.statuscode = statuscode;
            this.message = message;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
