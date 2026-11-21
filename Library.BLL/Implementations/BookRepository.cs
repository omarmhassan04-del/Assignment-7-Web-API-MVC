using Library.BLL.Interfaces;
using Library.DAL.Data;
using Library.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Implementations
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Book>> GetAllWithAuthorsAsync()
        {
            return await _dbSet
                .Include(b => b.Author)
                .Where(b => !b.IsDeleted)
                .ToListAsync();
        }

        public async Task<Book?> GetWithAuthorAsync(int id)
        {
            return await _dbSet
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
        }
    }
}
