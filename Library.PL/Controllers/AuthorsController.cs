using Library.BLL.Interfaces;
using Library.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.PL.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();
            return View(authors);
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest();

            var author = await _unitOfWork.Authors.GetAuthorWithBooksAsync(id.Value);
            if (author == null) return NotFound();

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                author.CreatedAt = DateTime.UtcNow;
                await _unitOfWork.Authors.CreateAsync(author);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            var author = await _unitOfWork.Authors.GetAsync(id.Value);
            if (author == null) return NotFound();

            return View(author);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Author author)
        {
            if (id != author.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                author.ModifiedAt = DateTime.UtcNow;
                _unitOfWork.Authors.Update(author);
                await _unitOfWork.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            var author = await _unitOfWork.Authors.GetAsync(id.Value);
            if (author == null) return NotFound();

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _unitOfWork.Authors.GetAsync(id);
            if (author == null) return NotFound();

            author.IsDeleted = true;
            author.ModifiedAt = DateTime.UtcNow;
            _unitOfWork.Authors.Update(author);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
