using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBRepository.Tables
{
    public class LoginHistory
    {
        [Key]
        public int Id { get; set; }
        public DateTime Logindatetime { get; set; }
        [StringLength(20)]
        public string IPaddress{get;set;}
        [StringLength(250)]
        public string Browsername { get; set; }
        public DateTime? Logoutdatetime { get; set; }
        public int LoginId { get; set; }
        [ForeignKey("LoginId")]
        public LoginDetails LoginDetails { get; set; }
    }
}
