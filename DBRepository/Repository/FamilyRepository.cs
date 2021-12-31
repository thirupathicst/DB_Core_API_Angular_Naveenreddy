using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository
{
    public class FamilyRepository : Repository<FamilyDetails>, IFamilyRepository
    {
        private readonly IPersonalInfoRepository _personalInfo;
        public FamilyRepository(NaveenReddyDbContext repositoryContext, IPersonalInfoRepository personalInfo) : base(repositoryContext)
        {
            _personalInfo = personalInfo;
        }

        public async Task<B_Family> SelectByIdAsync(int PersonId)
        {
            FamilyDetails familydetails = await base.GetSingleAsync(x => x.PersonId == PersonId);
            B_Family family = new B_Family();
            if (family != null)
            {
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

            }
            return family;
        }

        public async Task<B_Family> CreateAsync(B_Family familydetails)
        {
            PersonalInfo info = await _personalInfo.SelectByIdAsync(familydetails.PersonId);
            FamilyDetails family = new FamilyDetails
            {
                Brotheroccupation = familydetails.Brotheroccupation,
                Noofbrothersmarrried = familydetails.Noofbrothersmarrried,
                Noofbrothersunmarrried = familydetails.Noofbrothersunmarrried,
                Fathername = familydetails.Fathername,
                Fatheroccupation = familydetails.Fatheroccupation,
                Mothername = familydetails.Mothername,
                Motheroccupation = familydetails.Motheroccupation,
                Noofbrothers = familydetails.Noofbrothers,
                Noofsisters = familydetails.Noofsisters,
                Noofsistersmarrried = familydetails.Noofsistersmarrried,
                Noofsistersunmarrried = familydetails.Noofsistersunmarrried,
                Sisteroccupation = familydetails.Sisteroccupation,
                PersonId = info.PersonId,
                Createddatetime = DateTime.Now
            };

            await base.CreateAsync(family);
            await new PersonalInfoRepository(this.dbContext, null).UpdateProfileStage(5, info.PersonId);
            return familydetails;
        }

        public async Task<B_Family> UpdateAsync(B_Family familydetails)
        {
            FamilyDetails family = await base.GetSingleAsync(x => x.PersonId == familydetails.PersonId);
            if (family != null)
            {
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
                family.Updateddatetime = DateTime.Now;

                await base.UpdateAsync(family);
                return familydetails;
            }
            else
            {
                throw new NoDetailsFoundException();
            }
        }
    }
}
