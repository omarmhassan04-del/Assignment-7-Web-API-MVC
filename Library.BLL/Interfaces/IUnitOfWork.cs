using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        Task<int> SaveChangesAsync();
    }
}
