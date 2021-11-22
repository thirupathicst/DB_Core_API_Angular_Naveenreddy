using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
    public class LoginRepository: Repository<LoginDetails>, ILoginRepository
    {
        private readonly ILoginHistoryRepository repository;
        public LoginRepository(NaveenReddyDbContext repositoryContext, ILoginHistoryRepository _repository) : base(repositoryContext)
        {
            repository = _repository;
        }

        public async Task<B_Login> AddLogin(B_Login logindetails,B_LoginHistory history)
        {
            LoginDetails login = new LoginDetails
            {
                ActiveStatus = true,
                Emailid = logindetails.Emailid,
                Password = logindetails.Password,
                PersonId = logindetails.PersonId
            };
            await CreateAsync(login);

            history.LoginId = login.LoginId;
            await repository.AddLoginHistory(history);
            
            return logindetails;
        }
    }
}
