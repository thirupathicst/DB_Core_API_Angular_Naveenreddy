using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBRepository
{
    public class PersonalInfo
    {
        [Key]
        public int PersonId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int? Age { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string Timeofbirth { get; set; }
        public string Height { get; set; }
        public string Complexion { get; set; }
        [StringLength(100)]
        public string Emailid { get; set; }
        public long? Mobileno { get; set; }
        [StringLength(500)]
        public string Yourself { get; set; }
        [StringLength(10)]
        public string Generatedby { get; set; }
        [StringLength(20)]
        public string Maritalstatus { get; set; }
        [StringLength(100)]
        public string Placeofbirth { get; set; }
        [StringLength(10)]
        public string Profileid { get; set; }

    }

    public class EducationDetails
    {
        [Key]
        public int EducationId { get; set; }
        [StringLength(50)]
        public string School { get; set; }
        [StringLength(50)]
        public string College { get; set; }
        [StringLength(50)]
        public string Graducation { get; set; }
        [StringLength(50)]
        public string Heightqualification { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonalInfo PersonalInfo { get; set; }
    }

    public class AddressDetails
    {
        [Key]
        public int AddressId { get; set; }
        [StringLength(250)]
        public string PermanentAddress { get; set; }
        [StringLength(250)]
        public string ContactAddress { get; set; }
        public string Visa { get; set; }
        public int Pincode { get; set; }
        [StringLength(50)]
        public string District { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        public string Country { get; set; }
        [StringLength(50)]
        public string Settled { get; set; }
        [StringLength(50)]
        public string Native { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonalInfo PersonalInfo { get; set; }
    }


    public class ReligiousDetails
    {
        [Key]
        public int ReligiousId { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string Subcaste { get; set; }
        public string Star { get; set; }
        public string Raasi { get; set; }
        [StringLength(50)]
        public string Gothram { get; set; }
        public string MotherTongue { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonalInfo PersonalInfo { get; set; }
    }

    public class ProfessionalDetails
    {
        [Key]
        public int ProfessionalId { get; set; }
        public short Yearofstart { get; set; }
        [StringLength(100)]
        public string Joblocation { get; set; }
        public int Income { get; set; }
        [StringLength(100)]
        public string Companydetails { get; set; }
        [StringLength(20)]
        public string Jobtype { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonalInfo PersonalInfo { get; set; }
    }

    public class FamilyDetails
    {
        [Key]
        public int FamilyId { get; set; }
        [StringLength(100)]
        public string Fathername { get; set; }
        [StringLength(100)]
        public string Mothername { get; set; }
        [StringLength(50)]
        public string Brotheroccupation { get; set; }
        public short Noofbrothers { get; set; }
        public short Noofbrothersunmarrried { get; set; }
        public short Noofbrothersmarrried { get; set; }

        [StringLength(50)]
        public string Fatheroccupation { get; set; }
        [StringLength(50)]
        public string Motheroccupation { get; set; }
        public short Noofsisters { get; set; }
        public short Noofsistersmarrried { get; set; }
        public short Noofsistersunmarrried { get; set; }

        [StringLength(50)]
        public string Sisteroccupation { get; set; }
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public PersonalInfo PersonalInfo { get; set; }
    }
}
