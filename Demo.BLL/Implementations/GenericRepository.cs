using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BLL.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        protected DbSet<TEntity> _dbSet;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();

        }
        public async Task CreateAsync(TEntity entity)
            => await _dbSet.AddAsync(entity);

        public void Delete(TEntity entity)
            => _dbSet.Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<TEntity?> GetAsync(int id)
            => await _dbSet.FindAsync(id);

        public void Update(TEntity entity)
            => _dbSet.Update(entity);
    }
}
