using Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author?> GetAuthorWithBooksAsync(int id);
    }
}
