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
        private readonly IPersonalInfoRepository personalRepository;
        public LoginRepository(NaveenReddyDbContext repositoryContext, ILoginHistoryRepository _repository, IPersonalInfoRepository _personalRepository) : base(repositoryContext)
        {
            repository = _repository;
            personalRepository = _personalRepository;
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

        public B_UserInfo AddLogin(B_Login logindetails, B_LoginHistory history)
        {
            try
            {
                B_UserInfo info = new B_UserInfo();
                var data = SelectAll().Result;
                LoginDetails login = data.Where(x => x.Emailid == logindetails.Emailid && x.Password == logindetails.Password).FirstOrDefault();
                if (login != null)
                {
                    logindetails.Password = string.Empty;
                    history.LoginId = login.LoginId;
                    repository.AddLoginHistory(history);
                    info.Status = B_UserStatus.Active;
                    info.PersonId = login.LoginId;
                    var person = personalRepository.SelectById(login.PersonId).Result;
                    info.Profilestage = person.ProfileStage;
                }
                else
                {
                    info.Status = B_UserStatus.NoUser;
                }
                return info;
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
