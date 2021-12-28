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

        Task<B_PersonalInfo> GetRegistration(int PersonId);
        Task<B_Registration> AddRegistration(B_Registration b_Registration);

        Task<B_PersonalInfo> AddBioData(B_PersonalInfo b_PersonalInfo);

    }
}
