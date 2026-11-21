using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DAL.Models
{
    public class Loan : BaseEntity
    {
        [Required]
        public int BookId { get; set; }
        public virtual Book? Book { get; set; }

        [Required]
        public int BorrowerId { get; set; }
        public virtual Borrower? Borrower { get; set; }

        [Display(Name = "Loan Date")]
        [DataType(DataType.Date)]
        public DateTime LoanDate { get; set; } = DateTime.UtcNow;

        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
    }
}
