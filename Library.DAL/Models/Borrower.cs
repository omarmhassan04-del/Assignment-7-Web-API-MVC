using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.DAL.Models
{
    public class Borrower : BaseEntity
    {
        [Required(ErrorMessage = "Borrower Name is Required!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Borrower Name must be between 2 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        public string? Phone { get; set; }

        [Display(Name = "Membership Date")]
        [DataType(DataType.Date)]
        public DateTime MembershipDate { get; set; } = DateTime.UtcNow;

        // Navigation property (One Borrower -> Many Loans)
        public virtual ICollection<Loan> Loans { get; set; } = new Collection<Loan>();
    }
}
