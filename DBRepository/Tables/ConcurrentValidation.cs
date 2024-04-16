using System.ComponentModel.DataAnnotations;

namespace DBRepository.Tables
{
    public class ConcurrentValidation
    {
        [Timestamp]
        public byte[] Version { get; set; }
    }
}
