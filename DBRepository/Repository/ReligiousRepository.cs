using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
    public class ReligiousRepository: Repository<ReligiousDetails>, IReligiousRepository
    {
        private readonly IPersonalInfoRepository _personalInfo;
        public ReligiousRepository(NaveenReddyDbContext repositoryContext, IPersonalInfoRepository personalInfo) : base(repositoryContext)
        {
            _personalInfo = personalInfo;
        }

        public async Task<B_Religious> AddReligious(B_Religious religious)
        {
            PersonalInfo info = await _personalInfo.SelectById(religious.PersonId);
            ReligiousDetails religiousdetails = new ReligiousDetails();
            religiousdetails.Caste = religious.Caste;
            religiousdetails.Gothram = religious.Gothram;
            religiousdetails.Mothertongue = religious.MotherTongue;
            religiousdetails.Raasi = religious.Raasi;
            religiousdetails.Religion = religious.Religion;
            religiousdetails.Star = religious.Star;
            religiousdetails.Subcaste = religious.Subcaste;
            religiousdetails.PersonId = info.PersonId;

            await CreateAsync(religiousdetails);
            await new PersonalInfoRepository(this.dbContext, null).UpdateProfileStage(6, info.PersonId);
            return religious;
        }

        public async Task<B_Religious> UpdateReligious(B_Religious religious)
        {
            PersonalInfo info = await _personalInfo.SelectById(religious.PersonId);
            ReligiousDetails religiousdetails = new ReligiousDetails();
            religiousdetails.Caste = religious.Caste;
            religiousdetails.Gothram = religious.Gothram;
            religiousdetails.Mothertongue = religious.MotherTongue;
            religious.Raasi = religious.Raasi;
            religiousdetails.Religion = religious.Religion;
            religiousdetails.Star = religious.Star;
            religiousdetails.Subcaste = religious.Subcaste;
            religiousdetails.PersonId = info.PersonId;

            await UpdateAsync(religiousdetails);
            return religious;
        }
    }
}
