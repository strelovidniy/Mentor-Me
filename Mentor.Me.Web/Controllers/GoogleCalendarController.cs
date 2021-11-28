using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Calendar.v3;
using Mentor.Me.Domain.Models;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [Route("api/v1/calendar")]
    public class GoogleCalendarController : ControllerBase
    {
        private readonly IGoogleCalendarService _googleCalendarService;
        
        public GoogleCalendarController(IGoogleCalendarService googleCalendarService) => 
            _googleCalendarService = googleCalendarService;

        [Route("create")]
        [GoogleScopedAuthorize(CalendarService.ScopeConstants.CalendarEvents)]
        [GoogleScopedAuthorize(CalendarService.ScopeConstants.Calendar)]
        public async Task<IActionResult> CreateMeeting([FromServices] IGoogleAuthProvider auth, [FromBody]CreateMeetingModel model, CancellationToken ct)
        {
            await _googleCalendarService.CreateMeeting(model, auth, ct);
            return Ok();
        }
    }
}