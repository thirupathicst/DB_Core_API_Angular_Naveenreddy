using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaveenreddyAPI.Repository.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> SelectAll();
        Task<T> SelectById(int Id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
       Task<T> DeleteAsync(T entity);
    }
}
