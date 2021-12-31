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
    public class AddressRepository: Repository<AddressDetails>, IAddressRepository
    {
        private readonly IPersonalInfoRepository _personalInfo;
        public AddressRepository(NaveenReddyDbContext repositoryContext, IPersonalInfoRepository personalInfo) : base(repositoryContext)
        {
            _personalInfo = personalInfo;
        }

        public async Task<B_Address> SelectByIdAsync(int PersonId)
        {
            AddressDetails address = await base.GetSingleAsync(x => x.PersonId == PersonId);
            B_Address addressdetails = new B_Address();
            if (address != null)
            {
                addressdetails.Pincode = address.Pincode;
                addressdetails.ContactAddress = address.Contactaddress;
                addressdetails.Visa = address.Visa;
                addressdetails.District = address.District;
                addressdetails.State = address.State;
                addressdetails.Native = address.Native;
                addressdetails.Settled = address.Settled;
                addressdetails.Country = address.Country;
                addressdetails.PermanentAddress = $"{address.Country}${address.State}${ address.District}${address.Native}";
            }

            return addressdetails;
        }

        public async Task<B_Address> CreateAsync(B_Address address)
        {
            PersonalInfo info = await _personalInfo.SelectByIdAsync(address.PersonId);
            AddressDetails addressdetails = new AddressDetails();
            addressdetails.Contactaddress = address.ContactAddress;
            addressdetails.Pincode = address.Pincode;
            addressdetails.Visa = address.Visa;
            addressdetails.District = address.District;
            addressdetails.State = address.State;
            addressdetails.Native = address.Native;
            addressdetails.Settled = address.Settled;
            addressdetails.PersonId = info.PersonId;
            addressdetails.Country = address.Country;
            addressdetails.Permanentaddress = $"{address.PermanentAddress}${address.Country}${address.State}${ address.District}${address.Native}";
            addressdetails.Createddatetime = DateTime.Now;

            await base.CreateAsync(addressdetails);
            await new PersonalInfoRepository(this.dbContext, null).UpdateProfileStage(4, info.PersonId);
            return address;
        }

        public async Task<B_Address> UpdateAsync(B_Address address)
        {
            AddressDetails addressdetails = await GetSingleAsync(x => x.PersonId == address.PersonId);
            if (addressdetails != null)
            {
                addressdetails.Pincode = address.Pincode;
                addressdetails.Contactaddress = address.ContactAddress;
                addressdetails.Visa = address.Visa;
                addressdetails.District = address.District;
                addressdetails.State = address.State;
                addressdetails.Native = address.Native;
                addressdetails.Settled = address.Settled;
                addressdetails.Country = address.Country;
                addressdetails.Permanentaddress = $"{address.PermanentAddress}${address.Country}${address.State}${ address.District}${address.Native}";
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
