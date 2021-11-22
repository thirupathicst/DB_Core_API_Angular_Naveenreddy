using BusinesEntites;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository.Interfaces
{
    public interface IReligiousRepository: IRepository<ReligiousDetails>
    {
        Task<B_Religious> AddReligious(B_Religious religious);
        Task<B_Religious> UpdateReligious(B_Religious religious);
    }
}
