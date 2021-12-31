using BusinesEntites;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository.Interfaces
{
    public interface IProfessionalRepository:IRepository<ProfessionalDetails>
    {
        Task<B_Professional> SelectByIdAsync(int PersonId);
        Task<B_Professional> CreateAsync(B_Professional religious);
        Task<B_Professional> UpdateAsync(B_Professional religious);
    }
}
