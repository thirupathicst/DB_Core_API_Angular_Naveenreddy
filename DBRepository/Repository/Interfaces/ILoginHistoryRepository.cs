using BusinesEntites;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository.Interfaces
{
    public interface ILoginHistoryRepository: IRepository<LoginHistory>
    {
        Task<B_LoginHistory> CreateAsync(B_LoginHistory loginhistory);
    }
}
