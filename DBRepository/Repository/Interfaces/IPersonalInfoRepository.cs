using BusinesEntites;
using NaveenreddyAPI.Repository;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository.Interfaces
{
   public interface IPersonalInfoRepository: IRepository<PersonalInfo>
    {

        Task<B_PersonalInfo> GetPersonByIdAsync(int PersonId);
        Task<B_Registration> CreateAsync(B_Registration b_Registration);
        Task<B_PersonalInfo> CreateAsync(B_PersonalInfo b_PersonalInfo);
        Task<bool> UpdateProfileStage(int ProfileStage,int PersonId);

    }
}
