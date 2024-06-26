﻿using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Tables;

namespace DBRepository.Repository
{
    public class PersonalInfoRepository : Repository<PersonalInfo>, IPersonalInfoRepository
    {
        private readonly ILoginRepository repository;
        public PersonalInfoRepository(NaveenReddyDbContext repositoryContext, ILoginRepository _repository) : base(repositoryContext)
        {
            repository = _repository;
        }

        public async Task<B_PersonalInfo> GetPersonByIdAsync(int PersonId)
        {
            PersonalInfo personalInfo = await base.SelectByIdAsync(PersonId);
            B_PersonalInfo info = new B_PersonalInfo();
            if (personalInfo != null)
            {
                info.Name=personalInfo.Name;
                info.Mobileno = personalInfo.Mobileno.GetValueOrDefault();
                info.Height = personalInfo.Height.GetValueOrDefault();
                info.Gender = personalInfo.Gender;
                info.Dateofbirth = personalInfo.Dateofbirth.GetValueOrDefault();
                info.Timeofbirth = personalInfo.Timeofbirth;
                info.Complexion = personalInfo.Complexion;
                info.Yourself = personalInfo.Yourself;
                info.Maritalstatus = personalInfo.Maritalstatus;
                info.Placeofbirth = personalInfo.Placeofbirth;
                info.Age = personalInfo.Age.GetValueOrDefault();
            }
            return info;
        }

        public async Task<B_Registration> CreateAsync(B_Registration registration)
        {
            PersonalInfo info = new PersonalInfo();
            info.Emailid = registration.Email;
            info.Name = registration.Fullname;
            info.Generatedby = registration.Filledby;
            info.Createddatetime = DateTime.Now;

            await base.CreateAsync(info);

            LoginDetails login = new LoginDetails();
            login.ActiveStatus = true;
            login.Emailid = registration.Email;
            login.PersonId = info.PersonId;
            login.Password = registration.Password;

            registration.PersonId = info.PersonId;
            await repository.CreateAsync(login);

            return registration;
        }

        public async Task<B_PersonalInfo> CreateAsync(B_PersonalInfo personalInfo)
        {
            PersonalInfo info = await base.SelectByIdAsync(personalInfo.PersonId);
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
            info.ProfileStage = 1;
            await base.UpdateAsync(info);
            return personalInfo;
        }

        public async Task<bool> UpdateProfileStage(int ProfileStage,int PersonId)
        {
            PersonalInfo info = await base.SelectByIdAsync(PersonId);
            info.ProfileStage = ProfileStage;
            info.Updateddatetime = DateTime.Now;
            await base.UpdateAsync(info);
            return true;
        }

    }
}
