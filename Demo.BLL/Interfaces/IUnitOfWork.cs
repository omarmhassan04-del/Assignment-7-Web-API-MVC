using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.BLL.Interfaces
{
    public interface IUnitOfWork
    {
        IDepartmentRepository Departments { get; }
        Task<int> SaveChangesAsync();
    }
}
