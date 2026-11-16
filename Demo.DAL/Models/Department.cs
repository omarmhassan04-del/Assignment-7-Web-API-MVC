using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.DAL.Models
{
    public class Department : BaseEntity
    {
        [Range(0, 1000)]
        public int Code { get; set; }
        [Required(ErrorMessage = "Name is Required!")]
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        // Navigational Property (Many)
        public virtual ICollection<Employee> Employees { get; set; } = new Collection<Employee>();
    }
}
