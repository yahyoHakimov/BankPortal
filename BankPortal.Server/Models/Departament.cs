using System.ComponentModel.DataAnnotations;

namespace BankPortal.Server.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }

}
