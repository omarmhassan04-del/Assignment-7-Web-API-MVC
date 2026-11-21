using Library.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.PL.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 150 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; } = string.Empty;

        [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10000")]
        public decimal Price { get; set; }

        public string? Genre { get; set; }

        [Display(Name = "Publication Year")]
        public int PublicationYear { get; set; } = DateTime.Now.Year;

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; } = true;

        [Required(ErrorMessage = "Please select an author")]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }

        public string? AuthorName { get; set; }
    }
}
