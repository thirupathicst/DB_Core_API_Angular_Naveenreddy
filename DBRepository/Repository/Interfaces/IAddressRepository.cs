using BusinesEntites;
using DBRepository.Tables;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository.Interfaces
{
    public interface IAddressRepository: IRepository<AddressDetails>
    {
        new Task<B_Address> SelectByIdAsync(int PersonId);
        Task<B_Address> CreateAsync(B_Address address);
        Task<B_Address> UpdateAsync(B_Address address);
    }
}
