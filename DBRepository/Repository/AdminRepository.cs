using NaveenreddyAPI.DB;

namespace DBRepository.Repository
{
    public class AdminRepository:Repository<LoginDetails>
    {
        public AdminRepository(NaveenReddyDbContext repositoryContext) : base(repositoryContext)
        {
           
        }

    }
}