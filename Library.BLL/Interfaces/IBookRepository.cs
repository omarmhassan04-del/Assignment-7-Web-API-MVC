using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllWithAuthorsAsync();
        Task<Book?> GetWithAuthorAsync(int id);
    }
}
