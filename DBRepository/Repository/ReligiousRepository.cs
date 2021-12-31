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
    public class ReligiousRepository: Repository<ReligiousDetails>, IReligiousRepository
    {
        private readonly IPersonalInfoRepository _personalInfo;
        public ReligiousRepository(NaveenReddyDbContext repositoryContext, IPersonalInfoRepository personalInfo) : base(repositoryContext)
        {
            _personalInfo = personalInfo;
        }

        public async Task<B_Religious> SelectByIdAsync(int PersonId)
        {
            ReligiousDetails religious = await base.GetSingleAsync(x => x.PersonId == PersonId);
            B_Religious religiousdetails = new B_Religious();
            if (religious != null)
            {
                religiousdetails.Caste = religious.Caste;
                religiousdetails.Gothram = religious.Gothram;
                religiousdetails.MotherTongue = religious.Mothertongue;
                religiousdetails.Raasi = religious.Raasi;
                religiousdetails.Religion = religious.Religion;
                religiousdetails.Star = religious.Star;
                religiousdetails.Subcaste = religious.Subcaste;
            }

            return religiousdetails;
        }

        public async Task<B_Religious> CreateAsync(B_Religious religious)
        {
            PersonalInfo info = await _personalInfo.SelectByIdAsync(religious.PersonId);
            ReligiousDetails religiousdetails = new ReligiousDetails();
            religiousdetails.Caste = religious.Caste;
            religiousdetails.Gothram = religious.Gothram;
            religiousdetails.Mothertongue = religious.MotherTongue;
            religiousdetails.Raasi = religious.Raasi;
            religiousdetails.Religion = religious.Religion;
            religiousdetails.Star = religious.Star;
            religiousdetails.Subcaste = religious.Subcaste;
            religiousdetails.PersonId = info.PersonId;
            religiousdetails.Createddatetime = DateTime.Now;

            await base.CreateAsync(religiousdetails);
            await new PersonalInfoRepository(this.dbContext, null).UpdateProfileStage(6, info.PersonId);
            return religious;
        }

        public async Task<B_Religious> UpdateAsync(B_Religious religious)
        {
            PersonalInfo info = await _personalInfo.SelectByIdAsync(religious.PersonId);
            ReligiousDetails religiousdetails = new ReligiousDetails();
            religiousdetails.Caste = religious.Caste;
            religiousdetails.Gothram = religious.Gothram;
            religiousdetails.Mothertongue = religious.MotherTongue;
            religiousdetails.Raasi = religious.Raasi;
            religiousdetails.Religion = religious.Religion;
            religiousdetails.Star = religious.Star;
            religiousdetails.Subcaste = religious.Subcaste;
            religiousdetails.PersonId = info.PersonId;
            religiousdetails.Updateddatetime = DateTime.Now;

            await base.UpdateAsync(religiousdetails);
            return religious;
        }
    }
}
