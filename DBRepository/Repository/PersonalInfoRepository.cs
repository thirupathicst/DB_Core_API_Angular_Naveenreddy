using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
    public class PersonalInfoRepository : Repository<PersonalInfo>, IPersonalInfoRepository
    {
        private readonly ILoginRepository repository;
        public PersonalInfoRepository(NaveenReddyDbContext repositoryContext, ILoginRepository _repository) : base(repositoryContext)
        {
            repository = _repository;
        }

        public async Task<B_Registration> AddRegistration(B_Registration registration)
        {
            PersonalInfo info = new PersonalInfo();
            info.Emailid = registration.Email;
            info.Name = registration.Fullname;
            info.Generatedby = registration.Filledby;

            await CreateAsync(info);

            LoginDetails login = new LoginDetails();
            login.ActiveStatus = true;
            login.Emailid = registration.Email;
            login.PersonId = info.PersonId;
            login.Password = registration.Password;

            registration.PersonId = info.PersonId;
            await repository.CreateAsync(login);

            return registration;
        }

        public async Task<B_PersonalInfo> AddBioData(B_PersonalInfo personalInfo)
        {
            PersonalInfo info = await SelectById(personalInfo.PersonId);
            info.Mobileno = personalInfo.Mobileno;
            info.Height = personalInfo.Height;
            info.Gender = personalInfo.Gender;
            info.Dateofbirth = personalInfo.Dateofbirth;
            info.Timeofbirth = personalInfo.Timeofbirth;
            info.Complexion = personalInfo.Complexion;
            info.Yourself = personalInfo.Yourself;
            info.Maritalstatus = personalInfo.Maritalstatus;
            info.Placeofbirth= personalInfo.Placeofbirth;
            info.Age = new DateTime((DateTime.Now - info.Dateofbirth).Value.Ticks).Year - 1;

            await UpdateAsync(info);
            return personalInfo;
        }


    }
}
