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
}
