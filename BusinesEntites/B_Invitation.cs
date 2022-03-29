using System;
using System.Text.Json.Serialization;

namespace BusinesEntites
{
    public class B_Invitation
    {
        public int InvitationId { get; set; }
        public short Acceptedstatus { get; set; }
        public string Message { get; set; }
        public int Sentto { get; set; }
        public DateTime Invitationdatetime { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
    }
}