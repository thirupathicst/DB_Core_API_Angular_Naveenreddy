using System.Threading.Tasks;
using BusinesEntites;
using DBRepository.Tables;
using NaveenreddyAPI.Repository.Interfaces;

namespace DBRepository.Repository.Interfaces
{
    public interface IInvitationRepository : IRepository<Invitation>
    {
        Task<B_Invitation> CreateAsync(B_Invitation invitation);
        Task<B_Invitation> UpdateAsync(B_Invitation invitation);
    }
}