using System;
using System.Collections.Generic;
using System.Text;

namespace BusinesEntites
{
    public class B_ChangePassword
    {
        public int PersonId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
