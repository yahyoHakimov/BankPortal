using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Announcement
{
    public class ExternalMeetingDto
    {
        public int MeetingID { get; set; }          // The unique ID of the meeting (if applicable for editing or retrieving)
        public int OrganizerID { get; set; }        // The ID of the organizer (usually an EmployeeID)
        public string MeetingTitle { get; set; }    // The title or subject of the meeting
        public string MeetingURL { get; set; }      // The URL generated for the meeting (Google Meet, Calendly, etc.)
        public string Platform { get; set; }        // The platform used for the meeting (e.g., "Google Meet", "Calendly")
        public DateTime ScheduledAt { get; set; }   // The scheduled date and time of the meeting
        public List<int> ParticipantIDs { get; set; }  // A list of participant Employee IDs
    }

}
