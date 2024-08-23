using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ExternalMeeting
    {
        public int MeetingID { get; set; }
        public int OrganizerID { get; set; }
        public string MeetingTitle { get; set; }
        public string MeetingURL { get; set; }
        public DateTime ScheduledAt { get; set; }

        // Relationships
        public virtual Employee Organizer { get; set; }
        public virtual ICollection<Employee> Participants { get; set; }
    }
}
