using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DAL.Models
{
    public class Book : BaseEntity
    {
        [Required(ErrorMessage = "Title is Required!")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 150 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is Required!")]
        public string ISBN { get; set; } = string.Empty;

        [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10000")]
        public decimal Price { get; set; }

        public string? Genre { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string? CoverImageName { get; set; }

        // Navigation property (Many Books -> One Author)
        [Required(ErrorMessage = "Author is Required!")]
        public int AuthorId { get; set; }
        public virtual Author? Author { get; set; }

        // Navigation property (One Book -> Many Loans)
        public virtual ICollection<Loan> Loans { get; set; } = new Collection<Loan>();
    }
}
