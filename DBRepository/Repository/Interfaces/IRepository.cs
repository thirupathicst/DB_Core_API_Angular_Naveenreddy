using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NaveenreddyAPI.Repository.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> SelectAllAsync();
        Task<List<T>> SelectAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> SelectByIdAsync(int Id);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
