using DBRepository;
using Microsoft.EntityFrameworkCore;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NaveenreddyAPI.DB
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {

        protected readonly NaveenReddyDbContext dbContext;

        public Repository(NaveenReddyDbContext context)
        {
            dbContext = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            dbContext.Add(entity);
            await this.dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            this.dbContext.Update(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> GetSingle(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }
        
        public async Task<List<T>> SelectAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> SelectById(int Id)
        {
            return await dbContext.Set<T>().FindAsync(Id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
