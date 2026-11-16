using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DAL.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string? ImageName { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        // Navigational Property (One)
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
