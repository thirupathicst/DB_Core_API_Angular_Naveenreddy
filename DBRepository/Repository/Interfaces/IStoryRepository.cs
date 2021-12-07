using BusinesEntites;
using NaveenreddyAPI.DB;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository.Interfaces
{
    public interface IStoryRepository:IRepository<Story>
    {
        Task<B_Story> AddStory(B_Story story);
        Task<B_Story> UpdateStory(B_Story story);
    }
}
