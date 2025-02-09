using BusinesEntites;
using NaveenreddyAPI.DB;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository.Interfaces
{
    public interface IStoryRepository:IRepository<Story>
    {
        new Task<B_Story> SelectByIdAsync(int PersonId);
        Task<B_Story> CreateAsync(B_Story story);
        Task<B_Story> UpdateAsync(B_Story story);
    }
}
