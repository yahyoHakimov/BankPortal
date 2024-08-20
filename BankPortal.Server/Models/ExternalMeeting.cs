using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankPortal.Server.Models
{
    public class ExternalMeeting
    {
        [Key]
        public int MeetingId { get; set; }

        [ForeignKey("Organizer")]
        public int OrganizerId { get; set; }

        public Employee Organizer { get; set; }

        [Required]
        [MaxLength(100)]
        public string Topic { get; set; }

        public DateTime MeetingDate { get; set; }

        public ICollection<MeetingParticipant> Participants { get; set; }
    }

}
