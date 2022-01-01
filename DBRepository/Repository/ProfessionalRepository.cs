using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository
{
    public class ProfessionalRepository : Repository<ProfessionalDetails>, IProfessionalRepository
    {
        private readonly IPersonalInfoRepository _personalInfo;
        public ProfessionalRepository(NaveenReddyDbContext repositoryContext, IPersonalInfoRepository personalInfo) : base(repositoryContext)
        {
            _personalInfo = personalInfo;
        }

        public async Task<B_Professional> SelectByIdAsync(int PersonId)
        {
            ProfessionalDetails info = await base.GetSingleAsync(x => x.PersonId == PersonId);
            B_Professional professionaldetails = new B_Professional();
            if (info != null)
            {
                professionaldetails.Companydetails = info.Companydetails;
                professionaldetails.Income = info.Income;
                professionaldetails.Joblocation = info.Joblocation;
                professionaldetails.Jobtype = info.Jobtype;
                professionaldetails.Yearofstart = info.Yearofstart;
                professionaldetails.PersonId = info.PersonId;
                professionaldetails.Professiontype = info.Professiontype;
                professionaldetails.Professiondetails = info.Professiondetails;
            }
            return professionaldetails;
        }

        public async Task<B_Professional> CreateAsync(B_Professional professional)
        {
            ProfessionalDetails professionaldetails = await base.GetSingleAsync(x => x.PersonId == professional.PersonId);
            if (professionaldetails == null)
            {
                professionaldetails=new ProfessionalDetails();
                professionaldetails.Companydetails = professional.Companydetails;
                professionaldetails.Income = professional.Income;
                professionaldetails.Joblocation = professional.Joblocation;
                professionaldetails.Jobtype = professional.Jobtype;
                professionaldetails.Yearofstart = professional.Yearofstart;
                professionaldetails.Professiontype = professional.Professiontype;
                professionaldetails.Professiondetails = professional.Professiondetails;
                professionaldetails.PersonId = professional.PersonId;
                professionaldetails.Createddatetime = DateTime.Now;

                await base.CreateAsync(professionaldetails);
                await new PersonalInfoRepository(this.dbContext, null).UpdateProfileStage(3, professional.PersonId);
                return professional;
            }
            else
            {
                return new B_Professional();
            }
        }

        public async Task<B_Professional> UpdateAsync(B_Professional professional)
        {
            ProfessionalDetails professionaldetails = await base.GetSingleAsync(x => x.PersonId == professional.PersonId);
            if (professionaldetails != null)
            {
                professionaldetails.Companydetails = professional.Companydetails;
                professionaldetails.Income = professional.Income;
                professionaldetails.Joblocation = professional.Joblocation;
                professionaldetails.Jobtype = professional.Jobtype;
                professionaldetails.Yearofstart = professional.Yearofstart;
                professionaldetails.Professiontype = professional.Professiontype;
                professionaldetails.Professiondetails = professional.Professiondetails;
                professionaldetails.Updateddatetime = DateTime.Now;

                await base.UpdateAsync(professionaldetails);
                return professional;
            }
            else
            {
                throw new NoDetailsFoundException();
            }
        }
    }
}
