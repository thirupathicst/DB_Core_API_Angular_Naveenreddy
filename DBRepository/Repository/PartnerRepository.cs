using System.Threading.Tasks;
using BusinesEntites;
using DBRepository.Repository.Interfaces;
using DBRepository.Tables;
using NaveenreddyAPI.DB;

namespace DBRepository.Repository
{
    public class PartnerRepository : Repository<PartnerInfo>, IPartnerRepository
    {
        public PartnerRepository(NaveenReddyDbContext repositoryContext) : base(repositoryContext)
        {

        }

        public new async Task<B_Partner> SelectByIdAsync(int PersonId)
        {
            B_Partner partner = new B_Partner();
            var partnerInfo = await base.GetSingleAsync(x => x.PersonId == PersonId);
            if (partnerInfo != null)
            {
                partner.Age = partnerInfo.Age;
                partner.Height = partnerInfo.Height;
                partner.Complexion = partnerInfo.Complexion;
                partner.Caste = partnerInfo.Caste;
                partner.Citizen = partnerInfo.Citizen;
                partner.Country = partnerInfo.Country;
                partner.Maritalstatus = partnerInfo.Maritalstatus;
                partner.Mothertongue = partnerInfo.Mothertongue;
                partner.Education = partnerInfo.Education;
                partner.State = partnerInfo.State;
                partner.Occupation = partnerInfo.Occupation;
                partner.Religion = partnerInfo.Religion;
            }

            return partner;
        }

        public async Task<B_Partner> CreateAsync(B_Partner partner)
        {
            PartnerInfo partnerInfo = await base.GetSingleAsync(x => x.PersonId == partner.PersonId);
            if (partnerInfo == null)
            {
                partnerInfo = new PartnerInfo()
                {
                    Age = partner.Age,
                    Height = partner.Height,
                    Complexion = partner.Complexion,
                    Caste = partner.Caste,
                    Citizen = partner.Citizen,
                    Country = partner.Country,
                    Maritalstatus = partner.Maritalstatus,
                    Mothertongue = partner.Mothertongue,
                    Education = partner.Education,
                    State = partner.State,
                    Occupation = partner.Occupation,
                    Religion = partner.Religion,
                    PersonId = partner.PersonId,
                    Createddatetime = System.DateTime.Now
                };
                await base.CreateAsync(partnerInfo);
                return partner;
            }
            else
            {
                return new B_Partner();
            }
        }

        public async Task<B_Partner> UpdateAsync(B_Partner partner)
        {
            PartnerInfo partnerInfo = await base.GetSingleAsync(x => x.PersonId == partner.PersonId);
            if (partnerInfo != null)
            {
                partnerInfo.Age = partner.Age;
                partnerInfo.Height = partner.Height;
                partnerInfo.Complexion = partner.Complexion;
                partnerInfo.Caste = partner.Caste;
                partnerInfo.Citizen = partner.Citizen;
                partnerInfo.Country = partner.Country;
                partnerInfo.Maritalstatus = partner.Maritalstatus;
                partnerInfo.Mothertongue = partner.Mothertongue;
                partnerInfo.Education = partner.Education;
                partnerInfo.State = partner.State;
                partnerInfo.Occupation = partner.Occupation;
                partnerInfo.Religion = partner.Religion;
                partnerInfo.Updateddatetime = System.DateTime.Now;

                await base.UpdateAsync(partnerInfo);
                return partner;
            }
            else
            {
                throw new NoDetailsFoundException();
            }
        }

    }
}