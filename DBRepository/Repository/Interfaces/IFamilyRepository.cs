using BusinesEntites;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository.Interfaces
{
    public interface IFamilyRepository : IRepository<FamilyDetails>
    {
        Task<B_Family> CreateAsync(B_Family familydetails);

        Task<B_Family> UpdateAsync(B_Family familydetails);
    }
}
