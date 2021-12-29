using BusinesEntites;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository.Interfaces
{
    public interface IImageRepository : IRepository<Images>
    {
        Task<B_Images> CreateAsync(B_Images images);
        Task<B_Images> UpdateAsync(B_Images images);
    }
}
