using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DBRepository.Repository
{
    public class LoginRepository : Repository<LoginDetails>, ILoginRepository
    {
        private readonly ILoginHistoryRepository repository;
        public LoginRepository(NaveenReddyDbContext repositoryContext, ILoginHistoryRepository _repository) : base(repositoryContext)
        {
            repository = _repository;
        }

        public async Task<B_Login> AddLogin(B_Login logindetails)
        {
            LoginDetails login = new LoginDetails
            {
                ActiveStatus = true,
                Emailid = logindetails.Emailid,
                Password = logindetails.Password,
                PersonId = logindetails.PersonId
            };
            await CreateAsync(login);

            B_LoginHistory loginHistory = new B_LoginHistory
            {
                LoginId = login.LoginId,
                Logindatetime = DateTime.Now,
            };
            await repository.AddLoginHistory(loginHistory);

            return logindetails;
        }

        public async Task<B_Login> AddLogin(B_Login logindetails, B_LoginHistory history)
        {
            try
            {
                var data = await SelectAll();
                LoginDetails login = data.Where(x => x.Emailid == logindetails.Emailid && x.Password == logindetails.Password).FirstOrDefault();
                if (login != null)
                {
                    logindetails.Password = string.Empty;
                }

                history.LoginId = login.LoginId;
                await repository.AddLoginHistory(history);
                return logindetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // public async Task<B_Login> UserCheck(B_Login logindetails)
        // {
        //     var data = await SelectAll();
        //     LoginDetails login = data.Where(x => x.Emailid == logindetails.Emailid && x.Password == logindetails.Password).FirstOrDefault();
        //     if (login != null)
        //     {
        //         logindetails.Password = string.Empty;
        //         return logindetails;
        //     }
        //     else
        //         return new B_Login();
        // }

    }
}
