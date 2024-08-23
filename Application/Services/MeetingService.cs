using Application.DTOs;
using Application.DTOs.Announcement;
using Application.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IGoogleMeetService _googleMeetService; // Hypothetical external service for Google Meet

        public MeetingService(IMeetingRepository meetingRepository, IGoogleMeetService googleMeetService)
        {
            _meetingRepository = meetingRepository;
            _googleMeetService = googleMeetService;
        }

        public async Task<ExternalMeetingDto> ScheduleMeeting(ScheduleMeetingDto scheduleMeetingDto)
        {
            // Call Google Meet API or Calendly to get meeting URL
            var meetingUrl = await _googleMeetService.ScheduleGoogleMeetAsync(scheduleMeetingDto);

            // Create and save ExternalMeeting
            var meeting = new ExternalMeeting
            {
                OrganizerID = scheduleMeetingDto.OrganizerID,
                MeetingTitle = scheduleMeetingDto.MeetingTitle,
                MeetingURL = meetingUrl,
                ScheduledAt = scheduleMeetingDto.ScheduledAt
            };

            _meetingRepository.AddMeeting(meeting);

            return new ExternalMeetingDto
            {
                MeetingID = meeting.MeetingID,
                MeetingTitle = meeting.MeetingTitle,
                MeetingURL = meeting.MeetingURL,
                ScheduledAt = meeting.ScheduledAt
            };
        }

        public IEnumerable<ExternalMeetingDto> GetMeetingsByOrganizer(int organizerId)
        {
            var meetings = _meetingRepository.GetMeetingsByOrganizer(organizerId);
            // Mapping logic here...
            return meetings.Select(meeting => new ExternalMeetingDto
            {
                MeetingID = meeting.MeetingID,
                MeetingTitle = meeting.MeetingTitle,
                MeetingURL = meeting.MeetingURL,
                ScheduledAt = meeting.ScheduledAt
            });
        }
    }
}
