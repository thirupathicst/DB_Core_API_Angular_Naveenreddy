using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DBRepository.Tables;

namespace DBRepository.Repository
{
    public class LoginRepository : Repository<LoginDetails>, ILoginRepository
    {
        private readonly ILoginHistoryRepository repository;
        public LoginRepository(NaveenReddyDbContext repositoryContext, ILoginHistoryRepository _repository) : base(repositoryContext)
        {
            repository = _repository;
        }

        public async Task<B_Login> CreateAsync(B_Login logindetails)
        {
            LoginDetails login = new LoginDetails
            {
                ActiveStatus = true,
                Emailid = logindetails.Emailid,
                Password = logindetails.Password,
                PersonId = logindetails.PersonId
            };
            await base.CreateAsync(login);

            B_LoginHistory loginHistory = new B_LoginHistory
            {
                LoginId = login.LoginId,
                Logindatetime = DateTime.Now,
            };
            await repository.CreateAsync(loginHistory);

            return logindetails;
        }

        public async Task<B_UserInfo> CreateAsync(B_Login logindetails, B_LoginHistory history)
        {
            try
            {
                B_UserInfo info = new B_UserInfo();
                LoginDetails login = await base.GetSingleAsync(x => x.Emailid == logindetails.Emailid);
                if (login != null)
                {
                    if(!login.ActiveStatus)
                    {
                        info.Status = B_UserStatus.Inactive;
                    }
                    else if (login.Password.Equals(logindetails.Password)&& login.ActiveStatus)
                    {
                        logindetails.Password = string.Empty;
                        history.LoginId = login.LoginId;
                        await repository.CreateAsync(history);
                      
                        info.PersonId = login.PersonId;
                        var person = new PersonalInfoRepository(this.dbContext, null).SelectByIdAsync(login.PersonId).Result;
                        info.Profilestage = person.ProfileStage;
                        info.Status = B_UserStatus.Active;
                    }
                    else 
                    {
                        info.Status = B_UserStatus.Invalid;
                    }
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

        public async  Task<B_ChangePassword> ChangePassword(B_ChangePassword changepassword)
        {
            LoginDetails login = await base.GetSingleAsync(x => x.PersonId == changepassword.PersonId && x.Password == changepassword.OldPassword);
            if (login != null)
            {
                if(login.Password.Equals(changepassword.NewPassword))
                {
                    throw new MyCustomException("New password can't be same with old");
                }
                else if(changepassword.NewPassword.Equals(changepassword.ConfirmPassword))
                {
                    login.Password = changepassword.NewPassword;
                    await base.UpdateAsync(login);
                }
            }
            else{
                throw new NoDetailsFoundException("Inavlid credentials");
            }
            return changepassword;
        }

        public async Task<B_ForgotPassword> ForgotPassword(B_ForgotPassword forgotPassword )
        {
            LoginDetails login = await base.GetSingleAsync(x => x.Emailid == forgotPassword.EmailId && x.ActiveStatus == true);
            if (login != null)
            {
                return forgotPassword;
            }
            else{
                throw new MyCustomException("These Emailid & Mobile number not registerd");
            }
        }

    }
}
