using Application.DTOs;
using Application.DTOs.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMeetingService
    {
        Task<ExternalMeetingDto> ScheduleMeeting(ScheduleMeetingDto scheduleMeetingDto); // Schedule a new meeting
        IEnumerable<ExternalMeetingDto> GetMeetingsByOrganizer(int organizerId); // Get meetings organized by a specific user
    }
}
