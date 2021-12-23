using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinesEntites
{
    public enum B_UserStatus
    {
        /// <summary>
        /// Entered credentials are wrong.
        /// </summary>
        Invalid,

        /// <summary>
        /// No user exisit with current details.
        /// </summary>
        NoUser,

        /// <summary>
        /// User exisit, not in active.
        /// </summary>
        Inactive,

        /// <summary>
        /// User have negitive acitivity.
        /// </summary>
        Blocked,

        /// <summary>
        /// User exisit, all is good
        /// </summary>
        Active
    }

    public class B_UserInfo
    {
        public B_UserStatus Status {set;get; } 
        public string Message { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
        public int Profilestage { set; get; }
    }
}
