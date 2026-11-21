using Library.BLL.Interfaces;
using Library.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IBookRepository> _bookRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(_dbContext));
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_dbContext));
        }

        public IAuthorRepository Authors => _authorRepository.Value;
        public IBookRepository Books => _bookRepository.Value;

        public async Task<int> SaveChangesAsync()
            => await _dbContext.SaveChangesAsync();

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
