using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentID { get; set; }
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation Property
        public virtual User User { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
