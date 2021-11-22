﻿using DBRepository;
using Microsoft.EntityFrameworkCore;
using NaveenreddyAPI.Repository;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NaveenreddyAPI.DB
{
    public class Repository<T> : IRepository<T>where T :class,new()
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

        //public async Task CreateAsync<T>(T entity) where T : class
        //{
        //    this.dbContext.Set<T>().Add(entity);
        //    _ = await this.dbContext.SaveChangesAsync();
        //}

        //public async Task DeleteAsync<T>(T entity) where T : class
        //{
        //    this.dbContext.Set<T>().Remove(entity);
        //    _ = await this.dbContext.SaveChangesAsync();
        //}

        //public async Task<List<T>> SelectAll<T>() where T : class
        //{
        //    return await this.dbContext.Set<T>().ToListAsync();
        //}

        //public async Task<T> SelectById<T>(long id) where T : class
        //{
        //    return await this.dbContext.Set<T>().FindAsync(id);
        //}

        //public async Task UpdateAsync<T>(T entity) where T : class
        //{
        //    this.dbContext.Set<T>().Update(entity);
        //    _ = await this.dbContext.SaveChangesAsync();
        //}
    }
}
