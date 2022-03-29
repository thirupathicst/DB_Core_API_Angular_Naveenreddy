using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBRepository.Tables
{
    public class Invitation
    {
        [Key]
        public int InvitationId { get; set; }
        public short Acceptedstatus { get; set; }
        [StringLength(50)]
        public string Message { get; set; }
        public int Sentto{ get; set; }
        public DateTime Invitationdatetime { get; set; } = DateTime.Now;
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonalInfo PersonalInfo { get; set; }

    }
}