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
        Task<B_Family> AddFamilyDetails(B_Family familydetails);

        Task<B_Family> UpdateFamilyDetails(B_Family familydetails);
    }
}
