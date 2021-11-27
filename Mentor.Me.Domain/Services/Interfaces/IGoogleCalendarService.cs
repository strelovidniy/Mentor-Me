using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.AspNetCore3;
using Mentor.Me.Domain.Models;

namespace Mentor.Me.Domain.Interfaces
{
    public interface IGoogleCalendarService
    {
        Task CreateMeeting(CreateMeetingModel model, IGoogleAuthProvider googleAuthProvider, CancellationToken ct);
    }
}