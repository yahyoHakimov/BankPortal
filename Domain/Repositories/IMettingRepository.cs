using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMeetingRepository
    {
        void AddMeeting(ExternalMeeting meeting); // Add a new meeting to the database
        IEnumerable<ExternalMeeting> GetMeetingsByOrganizer(int organizerId); // Retrieve meetings by organizer
        void SaveChanges(); // Save changes to the context
        Task AddMeetingAsync(ExternalMeeting meeting);
        Task<ExternalMeeting> GetMeetingByIdAsync(int meetingId);
    }
}
