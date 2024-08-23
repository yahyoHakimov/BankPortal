using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly ApplicationDbContext _context;

        public MeetingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddMeeting(ExternalMeeting meeting)
        {
            _context.ExternalMeetings.Add(meeting);
            SaveChanges();
        }

        public IEnumerable<ExternalMeeting> GetMeetingsByOrganizer(int organizerId)
        {
            return _context.ExternalMeetings
                .Where(m => m.OrganizerID == organizerId)
                .ToList();
        }

        public async Task<ExternalMeeting> GetMeetingByIdAsync(int meetingId)
        {
            return await _context.ExternalMeetings.FindAsync(meetingId);
        }

        public async Task AddMeetingAsync(ExternalMeeting meeting)
        {
            await _context.ExternalMeetings.AddAsync(meeting);
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
