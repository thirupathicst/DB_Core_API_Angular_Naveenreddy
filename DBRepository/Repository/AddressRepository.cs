using BusinesEntites;
using DBRepository.Repository.Interfaces;
using NaveenreddyAPI.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository
{
    public class AddressRepository: Repository<AddressDetails>, IAddressRepository
    {
        private readonly IPersonalInfoRepository _personalInfo;
        public AddressRepository(NaveenReddyDbContext repositoryContext, IPersonalInfoRepository personalInfo) : base(repositoryContext)
        {
            _personalInfo = personalInfo;
        }

        public async Task<B_Address> AddAddress(B_Address address)
        {
            PersonalInfo info = await _personalInfo.SelectById(address.PersonId);
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
            addressdetails.Permanentaddress = $"{address.Country}${address.State}${ address.District}${address.Native}";

            await CreateAsync(addressdetails);
            await new PersonalInfoRepository(this.dbContext, null).UpdateProfileStage(4, info.PersonId);
            return address;
        }

        public async Task<B_Address> UpdateAddress(B_Address address)
        {
            // PersonalInfo info = await SelectById(address.PersonId);
            AddressDetails addressdetails = await SelectById(address.PersonId);
            addressdetails.Pincode = address.Pincode;
            addressdetails.Contactaddress = address.ContactAddress;
            addressdetails.Visa = address.Visa;
            addressdetails.District = address.District;
            addressdetails.State = address.State;
            addressdetails.Native = address.Native;
            addressdetails.Settled = address.Settled;
            addressdetails.Country = address.Country;
            addressdetails.Permanentaddress = $"{address.Country}${address.State}${ address.District}${address.Native}";

            await UpdateAsync(addressdetails);
            return address;
        }
    }
}
