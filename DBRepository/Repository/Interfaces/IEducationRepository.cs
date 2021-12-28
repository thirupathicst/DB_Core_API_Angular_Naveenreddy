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
        Task<B_Education> AddEducationDetails(B_Education educationdetails);

        Task<B_Education> UpdateEducationDetails(B_Education educationdetails);
    }
}
