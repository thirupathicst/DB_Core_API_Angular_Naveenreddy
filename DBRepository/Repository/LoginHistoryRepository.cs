using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
    public class LoginHistoryRepository: Repository<LoginHistory>, ILoginHistoryRepository
    {
        public LoginHistoryRepository(NaveenReddyDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<B_LoginHistory> AddLoginHistory(B_LoginHistory loginhistory)
        {
            LoginHistory history = new LoginHistory
            {
                Browsername = loginhistory.Browsername,
                IPaddress = loginhistory.IPaddress,
                Logindatetime = DateTime.Now,
                LoginId = loginhistory.LoginId,
            };

            await CreateAsync(history);
            return loginhistory;
        }
    }
}
