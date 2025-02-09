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
   public  interface IEducationRepository : IRepository<EducationDetails>
    {
        new Task<B_Education> SelectByIdAsync(int PersonId);
        Task<B_Education> CreateAsync(B_Education educationdetails);
        Task<B_Education> UpdateAsync(B_Education educationdetails);
    }
}
