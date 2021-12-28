using System.Threading.Tasks;
using BusinesEntites;
using DBRepository.Tables;
using NaveenreddyAPI.Repository.Interfaces;

namespace DBRepository.Repository.Interfaces
{
    public interface IPartnerRepository : IRepository<PartnerInfo>
    {
        Task<B_Partner> GetPartner(int PersonId);
        Task<B_Partner> AddPartner(B_Partner partner);
    }
}