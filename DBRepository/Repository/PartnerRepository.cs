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

        public async Task<B_Partner> GetPartner(int PersonId)
        {
            B_Partner partner = new B_Partner();
           
            var partnerInfo = await GetSingle(x=>x.PersonId==PersonId);
            partner.Age = partnerInfo.Age;
            partner.Height=partnerInfo.Height;
            partner.Complexion = partnerInfo.Complexion;
            partner.Caste = partnerInfo.Caste;
            partner.Citizen = partnerInfo.Citizen;
            partner.Country = partnerInfo.Country;
            partner.Maritalstatus = partnerInfo.Maritalstatus;
            partner.Mothertongue = partnerInfo.Mothertongue;
            partner.Education = partnerInfo.Education;
            partner.State = partnerInfo.State;
            partner.Occupation = partner.Occupation;
            partnerInfo.Region = partnerInfo.Region;

            return partner;
        }

        public async Task<B_Partner> AddPartner(B_Partner partner)
        {
            var _partnerInfo = await SelectById(partner.PersonId);
            if (_partnerInfo != null)
            {
                await this.UpdatePartner(partner, _partnerInfo);
            }
            else
            {
                PartnerInfo partnerInfo = new PartnerInfo()
                {
                    Age = partner.Age,
                    Height=partner.Height,
                    Complexion = partner.Complexion,
                    Caste = partner.Caste,
                    Citizen = partner.Citizen,
                    Country = partner.Country,
                    Maritalstatus = partner.Maritalstatus,
                    Mothertongue = partner.Mothertongue,
                    Education = partner.Education,
                    State = partner.State,
                    Occupation = partner.Occupation,
                    Region = partner.Region,
                    PersonId = partner.PersonId,
                    Createddatetime=System.DateTime.Now
                };
                await this.CreateAsync(partnerInfo);
            }
            return partner;
        }

        private async Task UpdatePartner(B_Partner partner, PartnerInfo partnerInfo)
        {
            partnerInfo.Age = partner.Age;
            partnerInfo.Height=partner.Height;
            partnerInfo.Complexion = partner.Complexion;
            partnerInfo.Caste = partner.Caste;
            partnerInfo.Citizen = partner.Citizen;
            partnerInfo.Country = partner.Country;
            partnerInfo.Maritalstatus = partner.Maritalstatus;
            partnerInfo.Mothertongue = partner.Mothertongue;
            partnerInfo.Education = partner.Education;
            partnerInfo.State = partner.State;
            partnerInfo.Occupation = partner.Occupation;
            partnerInfo.Region = partner.Region;
            partnerInfo.Updateddatetime=System.DateTime.Now;

            await this.UpdateAsync(partnerInfo);
        }

    }
}