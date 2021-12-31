using BusinesEntites;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository.Interfaces
{
    public interface IReligiousRepository: IRepository<ReligiousDetails>
    {
        Task<B_Religious> SelectByIdAsync(int PersonId);
        Task<B_Religious> CreateAsync(B_Religious religious);
        Task<B_Religious> UpdateAsync(B_Religious religious);
    }
}
