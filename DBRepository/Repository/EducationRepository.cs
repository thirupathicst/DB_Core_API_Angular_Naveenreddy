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
    public class EducationRepository : Repository<EducationDetails>, IEducationRepository
    {
        private readonly IPersonalInfoRepository _personalInfo;
        public EducationRepository(NaveenReddyDbContext repositoryContext, IPersonalInfoRepository personalInfo) : base(repositoryContext)
        {
            _personalInfo = personalInfo;
        }

        public async Task<B_Education> SelectByIdAsync(int PersonId)
        {
            EducationDetails info = await base.GetSingleAsync(x => x.PersonId == PersonId);
            B_Education education = new B_Education();
            if (info != null)
            {
                education.College = info.College;
                education.Graducation = info.Graducation;
                education.Heightqualification = info.Heightqualification;
                education.School = info.School;
            }
            return education;
        }

        public async Task<B_Education> CreateAsync(B_Education educationdetails)
        {
            EducationDetails education = await base.GetSingleAsync(x => x.PersonId == educationdetails.PersonId);
            if (education == null)
            {
                education = new EducationDetails();
                education.College = educationdetails.College;
                education.Graducation = educationdetails.Graducation;
                education.Heightqualification = educationdetails.Heightqualification;
                education.School = educationdetails.School;
                education.PersonId = educationdetails.PersonId;
                education.Createddatetime = DateTime.Now;

                await base.CreateAsync(education);
                await new PersonalInfoRepository(this.dbContext, null).UpdateProfileStage(2, educationdetails.PersonId);
                return educationdetails;
            }
            else
            {
                return new B_Education();
            }
        }

        public async Task<B_Education> UpdateAsync(B_Education educationdetails)
        {
            EducationDetails education = await base.GetSingleAsync(x => x.PersonId == educationdetails.PersonId);
            if (education != null)
            {
                education.College = educationdetails.College;
                education.Graducation = educationdetails.Graducation;
                education.Heightqualification = educationdetails.Heightqualification;
                education.School = educationdetails.School;
                education.Updateddatetime = DateTime.Now;

                await base.UpdateAsync(education);
                return educationdetails;
            }
            else
            {
                throw new NoDetailsFoundException();
            }
        }

    }
}
