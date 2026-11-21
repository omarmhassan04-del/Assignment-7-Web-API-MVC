using Library.BLL.Interfaces;
using Library.DAL.Data;
using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

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
            => await _dbSet.Where(e => !e.IsDeleted).ToListAsync();

        public async Task<TEntity?> GetAsync(int id)
            => await _dbSet.FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);

        public void Update(TEntity entity)
            => _dbSet.Update(entity);
    }
}
