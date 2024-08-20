using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankPortal.Server.Models
{
    public class MeetingParticipant
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Meeting")]
        public int MeetingId { get; set; }

        public ExternalMeeting Meeting { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Participant")]
        public int ParticipantId { get; set; }

        public Employee Participant { get; set; }
    }

}
