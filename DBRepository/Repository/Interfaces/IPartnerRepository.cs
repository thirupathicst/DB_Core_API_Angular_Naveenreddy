using System.Threading.Tasks;
using BusinesEntites;
using DBRepository.Tables;
using NaveenreddyAPI.Repository.Interfaces;

namespace DBRepository.Repository.Interfaces
{
    public interface IPartnerRepository : IRepository<PartnerInfo>
    {
        new Task<B_Partner> SelectByIdAsync(int PersonId);
        Task<B_Partner> CreateAsync(B_Partner partner);
        Task<B_Partner> UpdateAsync(B_Partner partner);
    }
}