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
    public class AddressRepository : Repository<AddressDetails>, IAddressRepository
    {
        private readonly IPersonalInfoRepository _personalInfo;
        public AddressRepository(NaveenReddyDbContext repositoryContext, IPersonalInfoRepository personalInfo) : base(repositoryContext)
        {
            _personalInfo = personalInfo;
        }

        public new async Task<B_Address> SelectByIdAsync(int PersonId)
        {
            AddressDetails address = await base.GetSingleAsync(x => x.PersonId == PersonId);
            B_Address addressdetails = new B_Address();
            if (address != null)
            {
                addressdetails.ContactAddress = address.Contactaddress;
                addressdetails.Visa = address.Visa;
                addressdetails.District = address.District;
                addressdetails.State = address.State;
                addressdetails.Native = address.Native;
                addressdetails.Settled = address.Settled;
                addressdetails.Country = address.Country;
                addressdetails.PermanentAddress = address.Contactaddress;
            }

            return addressdetails;
        }

        public async Task<B_Address> CreateAsync(B_Address address)
        {
            AddressDetails addressdetails = await GetSingleAsync(x => x.PersonId == address.PersonId);
            if (addressdetails == null)
            {
                addressdetails = new AddressDetails();
                addressdetails.Contactaddress = address.ContactAddress;
                addressdetails.Visa = address.Visa;
                addressdetails.District = address.District;
                addressdetails.State = address.State;
                addressdetails.Native = address.Native;
                addressdetails.Settled = address.Settled;
                addressdetails.PersonId = address.PersonId;
                addressdetails.Country = address.Country;
                addressdetails.Permanentaddress = address.PermanentAddress;
                addressdetails.Createddatetime = DateTime.Now;

                await base.CreateAsync(addressdetails);
                await new PersonalInfoRepository(this.dbContext, null).UpdateProfileStage(4, address.PersonId);
                return address;
            }
            else
            {
                return new B_Address();
            }
        }

        public async Task<B_Address> UpdateAsync(B_Address address)
        {
            AddressDetails addressdetails = await GetSingleAsync(x => x.PersonId == address.PersonId);
            if (addressdetails != null)
            {
                addressdetails.Contactaddress = address.ContactAddress;
                addressdetails.Visa = address.Visa;
                addressdetails.District = address.District;
                addressdetails.State = address.State;
                addressdetails.Native = address.Native;
                addressdetails.Settled = address.Settled;
                addressdetails.Country = address.Country;
                addressdetails.Permanentaddress = address.PermanentAddress;
                addressdetails.Updateddatetime = DateTime.Now;

                await base.UpdateAsync(addressdetails);
                return address;
            }
            else
            {
                throw new NoDetailsFoundException();
            }
        }
    }
}
