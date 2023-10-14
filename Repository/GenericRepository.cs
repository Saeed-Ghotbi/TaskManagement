﻿using Microsoft.EntityFrameworkCore;
using TaskManagement.Context;
using TaskManagement.Contracts.Repository;

namespace TaskManagement.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TaskManagementContext _dbContext;

        public GenericRepository(TaskManagementContext context)
        {
            _dbContext = context;
        }
        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
