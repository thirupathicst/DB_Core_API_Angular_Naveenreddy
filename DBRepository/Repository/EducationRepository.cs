using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
    public class EducationRepository: Repository<EducationDetails>, IEducationRepository
    {
        private readonly IPersonalInfoRepository _personalInfo;
        public EducationRepository(NaveenReddyDbContext repositoryContext, IPersonalInfoRepository personalInfo) : base(repositoryContext)
        {
            _personalInfo = personalInfo;
        }

        public async Task<B_Education> AddEducationDetails(B_Education educationdetails)
        {
            PersonalInfo info = await _personalInfo.SelectById(educationdetails.PersonId);
            EducationDetails education = new EducationDetails();
            education.College = educationdetails.College;
            education.Graducation = educationdetails.Graducation;
            education.Heightqualification = educationdetails.Heightqualification;
            education.School = educationdetails.School;
            education.PersonId = info.PersonId;
            education.Createddatetime = DateTime.Now;

             await CreateAsync(education);
            await new PersonalInfoRepository(this.dbContext, null).UpdateProfileStage(2, info.PersonId);
            return educationdetails;
        }

        public async Task<B_Education> UpdateEducationDetails(B_Education educationdetails)
        {
            PersonalInfo info = await _personalInfo.SelectById(educationdetails.PersonId);
            EducationDetails education = new EducationDetails();
            education.College = educationdetails.College;
            education.Graducation = educationdetails.Graducation;
            education.Heightqualification = educationdetails.Heightqualification;
            education.School = educationdetails.School;
            education.Updateddatetime = DateTime.Now;

            await UpdateAsync(education);

            return educationdetails;
        }

    }
}
