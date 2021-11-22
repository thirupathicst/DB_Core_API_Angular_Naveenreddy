using BusinesEntites;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository.Interfaces
{
    public interface IAddressRepository: IRepository<AddressDetails>
    {
        Task<B_Address> AddAddress(B_Address address);
        Task<B_Address> UpdateAddress(B_Address address);
    }
}
