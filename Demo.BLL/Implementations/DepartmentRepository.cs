using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BLL.Implementations
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
