using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankPortal.Server.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime RequestDate { get; set; }
    }

}
