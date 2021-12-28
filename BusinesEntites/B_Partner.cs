using System.Text.Json.Serialization;

namespace BusinesEntites
{
    public class B_Partner
    {
        public int PartnerId { get; set; }
        public int Age { get; set; }

        public int Height { get; set; }

        public string Maritalstatus { get; set; }

        public string Complexion { get; set; }

        public string Region { get; set; }

        public string Mothertongue { get; set; }

        public string Caste { get; set; }

        public string Education { get; set; }

        public string Occupation { get; set; }

        public string Citizen { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        [JsonIgnore]
        public int PersonId { get; set; }
    }
}