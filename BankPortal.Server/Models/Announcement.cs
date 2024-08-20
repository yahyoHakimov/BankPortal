using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankPortal.Server.Models
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public Employee Author { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime AnnouncementDate { get; set; }
    }

}
