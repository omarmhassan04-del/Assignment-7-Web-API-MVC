using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DAL.Models
{
    public class Author : BaseEntity
    {
        [Required(ErrorMessage = "Author Name is Required!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Author Name must be between 2 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string? Biography { get; set; }

        // Navigation property (One Author -> Many Books)
        public virtual ICollection<Book> Books { get; set; } = new Collection<Book>();
    }
}
