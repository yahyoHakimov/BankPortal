using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsController : ControllerBase
    {
        private readonly IGoogleMeetService _googleMeetService;

        public MeetingsController(IGoogleMeetService googleMeetService)
        {
            _googleMeetService = googleMeetService;
        }

        [HttpPost("schedule")]
        public async Task<IActionResult> ScheduleMeeting([FromBody] ScheduleMeetingDto dto)
        {
            string meetingUrl = await _googleMeetService.ScheduleGoogleMeetAsync(dto);

            return Ok(new { MeetingUrl = meetingUrl });
        }
    }

}
