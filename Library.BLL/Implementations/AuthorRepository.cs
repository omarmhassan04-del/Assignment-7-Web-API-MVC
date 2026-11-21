using Library.BLL.Interfaces;
using Library.DAL.Data;
using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Implementations
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Author?> GetAuthorWithBooksAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Books.Where(b => !b.IsDeleted))
                .FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }
    }
}
