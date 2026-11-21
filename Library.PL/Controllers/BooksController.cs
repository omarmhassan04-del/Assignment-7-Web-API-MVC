using Library.BLL.Interfaces;
using Library.DAL.Models;
using Library.PL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.PL.Controllers
{
    public class BooksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _unitOfWork.Books.GetAllWithAuthorsAsync();
            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            var book = await _unitOfWork.Books.GetWithAuthorAsync(id.Value);
            if (book == null) return NotFound();

            return View(book);
        }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            await PopulateAuthorsDropDownListAsync();
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.CreatedAt = DateTime.UtcNow;
                await _unitOfWork.Books.CreateAsync(book);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await PopulateAuthorsDropDownListAsync(book.AuthorId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            var book = await _unitOfWork.Books.GetAsync(id.Value);
            if (book == null) return NotFound();

            await PopulateAuthorsDropDownListAsync(book.AuthorId);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                book.ModifiedAt = DateTime.UtcNow;
                _unitOfWork.Books.Update(book);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await PopulateAuthorsDropDownListAsync(book.AuthorId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var book = await _unitOfWork.Books.GetWithAuthorAsync(id.Value);
            if (book == null) return NotFound();

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _unitOfWork.Books.GetAsync(id);
            if (book == null) return NotFound();

            book.IsDeleted = true;
            book.ModifiedAt = DateTime.UtcNow;
            _unitOfWork.Books.Update(book);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateAuthorsDropDownListAsync(object? selectedAuthor = null)
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();
            ViewBag.AuthorId = new SelectList(authors, "Id", "Name", selectedAuthor);
        }
    }
}
