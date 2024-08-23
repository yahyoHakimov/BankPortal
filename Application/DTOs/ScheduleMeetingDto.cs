using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ScheduleMeetingDto
    {
        public string OrganizerEmail { get; set; }
        public List<string> ParticipantEmails { get; set; }
        public int OrganizerID { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string MeetingTitle { get; set; }
        public string Platform { get; set; } = "Google Meet"; // Default platform set to Google Meet
    }

}
