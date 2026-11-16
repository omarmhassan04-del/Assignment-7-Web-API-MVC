using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BLL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(_dbContext));
        }
        public IDepartmentRepository Departments => _departmentRepository.Value;

        public async Task<int> SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();
    }
    // TODO: Add Department Controller + Department Views
}
