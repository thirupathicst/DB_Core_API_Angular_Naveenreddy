using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
    public class FamilyRepository: Repository<FamilyDetails>, IFamilyRepository
    {
        private readonly IPersonalInfoRepository _personalInfo;
        public FamilyRepository(NaveenReddyDbContext repositoryContext, IPersonalInfoRepository personalInfo) : base(repositoryContext)
        {
            _personalInfo = personalInfo;
        }

        public async Task<B_Family> AddFamilyDetails(B_Family familydetails)
        {
            PersonalInfo info = await _personalInfo.SelectById(familydetails.PersonId);
            FamilyDetails family = new FamilyDetails
            {
                Brotheroccupation = familydetails.Brotheroccupation,
                Noofbrothersmarrried=familydetails.Noofbrothersmarrried,
                Noofbrothersunmarrried=familydetails.Noofbrothersunmarrried,
                Fathername = familydetails.Fathername,
                Fatheroccupation = familydetails.Fatheroccupation,
                Mothername = familydetails.Mothername,
                Motheroccupation = familydetails.Motheroccupation,
                Noofbrothers = familydetails.Noofbrothers,
                Noofsisters = familydetails.Noofsisters,
                Noofsistersmarrried=familydetails.Noofsistersmarrried,
                Noofsistersunmarrried=familydetails.Noofsistersunmarrried,
                Sisteroccupation = familydetails.Sisteroccupation,
                PersonId = info.PersonId
            };

            await CreateAsync(family);

            return familydetails;
        }

        public async Task<B_Family> UpdateFamilyDetails(B_Family familydetails)
        {

            FamilyDetails family =await SelectById(familydetails.PersonId);
            if(family==null)
            {
            }
            family.Brotheroccupation = familydetails.Brotheroccupation;
            family.Noofbrothersmarrried = familydetails.Noofbrothersmarrried;
            family.Noofbrothersunmarrried = familydetails.Noofbrothersunmarrried;
            family.Fathername = familydetails.Fathername;
            family.Fatheroccupation = familydetails.Fatheroccupation;
            family.Mothername = familydetails.Mothername;
            family.Motheroccupation = familydetails.Motheroccupation;
            family.Noofbrothers = familydetails.Noofbrothers;
            family.Noofsisters = familydetails.Noofsisters;
            family.Noofsistersmarrried = familydetails.Noofsistersmarrried;
            family.Noofsistersunmarrried = familydetails.Noofsistersunmarrried;
            family.Sisteroccupation = familydetails.Sisteroccupation;

            await UpdateAsync(family);

            return familydetails;
        }
    }
}
