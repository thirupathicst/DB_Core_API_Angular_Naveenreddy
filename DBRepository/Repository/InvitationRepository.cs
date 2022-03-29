using System.Threading.Tasks;
using BusinesEntites;
using DBRepository.Repository.Interfaces;
using DBRepository.Tables;
using NaveenreddyAPI.DB;

namespace DBRepository.Repository
{
    public class InvitationRepository : Repository<Invitation>, IInvitationRepository
    {
        public InvitationRepository(NaveenReddyDbContext repositoryContext) : base(repositoryContext)
        {

        }
        public async Task<B_Invitation> CreateAsync(B_Invitation invitation)
        {
            Invitation _invitation = new Invitation()
            {
                PersonId = invitation.PersonId,
                Sentto = invitation.Sentto,
                Message = invitation.Message,
                Acceptedstatus = invitation.Acceptedstatus,
            };
            await base.CreateAsync(_invitation);
            return invitation;
        }

        public async Task<B_Invitation> UpdateAsync(B_Invitation invitation)
        {
            Invitation _invitation = await base.GetSingleAsync(x => x.PersonId == invitation.PersonId && x.InvitationId == invitation.InvitationId);
            _invitation.Acceptedstatus = 1;
            await base.UpdateAsync(_invitation);
            return invitation;
        }
    }
}