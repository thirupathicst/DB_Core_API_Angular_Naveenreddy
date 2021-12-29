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
    public class ProfessionalRepository: Repository<ProfessionalDetails>, IProfessionalRepository
    {
        private readonly IPersonalInfoRepository _personalInfo;
        public ProfessionalRepository(NaveenReddyDbContext repositoryContext, IPersonalInfoRepository personalInfo) : base(repositoryContext)
        {
            _personalInfo = personalInfo;
        }

        public async Task<B_Professional> CreateAsync(B_Professional professional)
        {
            PersonalInfo info = await _personalInfo.SelectById(professional.PersonId);
            ProfessionalDetails professionaldetails = new ProfessionalDetails();
            professionaldetails.Companydetails = professional.Companydetails;
            professionaldetails.Income = professional.Income;
            professionaldetails.Joblocation = professional.Joblocation;
            professionaldetails.Jobtype = professional.Jobtype;
            professionaldetails.Yearofstart = professional.Yearofstart;
            professionaldetails.PersonId = info.PersonId;
            professionaldetails.Createddatetime = DateTime.Now;

            await base.CreateAsync(professionaldetails);
            await new PersonalInfoRepository(this.dbContext, null).UpdateProfileStage(3, info.PersonId);
            return professional;
        }

        public async Task<B_Professional> UpdateAsync(B_Professional professional)
        {
            PersonalInfo info = await _personalInfo.SelectById(professional.PersonId);
            ProfessionalDetails professionaldetails = new ProfessionalDetails();
            professionaldetails.Companydetails = professional.Companydetails;
            professionaldetails.Income = professional.Income;
            professionaldetails.Joblocation = professional.Joblocation;
            professionaldetails.Jobtype = professional.Jobtype;
            professionaldetails.Yearofstart = professional.Yearofstart;
            professionaldetails.PersonId = info.PersonId;
            professionaldetails.Updateddatetime = DateTime.Now;

            await base.UpdateAsync(professionaldetails);
            return professional;
        }
    }
}
