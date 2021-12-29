using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository
{
    public class LoginHistoryRepository: Repository<LoginHistory>, ILoginHistoryRepository
    {
        public LoginHistoryRepository(NaveenReddyDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<B_LoginHistory> CreateAsync(B_LoginHistory loginhistory)
        {
            LoginHistory history = new LoginHistory
            {
                Browsername = loginhistory.Browsername,
                IPaddress = loginhistory.IPaddress,
                Logindatetime = DateTime.Now,
                LoginId = loginhistory.LoginId,
            };

            await base.CreateAsync(history);
            return loginhistory;
        }
    }
}
