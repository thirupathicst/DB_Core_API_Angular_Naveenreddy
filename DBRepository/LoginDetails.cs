using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBRepository
{
    public class LoginDetails
    {
        [Key]
        public int LoginId { get; set; }
        [StringLength(100)]
        public string Emailid { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public bool ActiveStatus { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonalInfo PersonalInfo { get; set; }
    }


}
