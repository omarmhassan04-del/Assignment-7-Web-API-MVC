using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BLL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity?> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
