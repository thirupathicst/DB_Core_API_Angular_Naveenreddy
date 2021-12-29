using BusinesEntites;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository.Interfaces
{
    public interface ILoginRepository:IRepository<LoginDetails>
    {
        Task<B_Login> CreateAsync(B_Login logindetails);
        B_UserInfo CreateAsync(B_Login logindetails, B_LoginHistory history);
        Task<B_ChangePassword> ChangePassword(B_ChangePassword changepassword);
        Task<B_ForgotPassword> ForgotPassword(B_ForgotPassword forgotPassword );
    }
}
