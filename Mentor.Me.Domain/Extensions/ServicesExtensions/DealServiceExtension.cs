using Mentor.Me.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mentor.Me.Domain.Extensions.ServicesExtensions
{
    public static class DealServiceExtension
    {
        public static IQueryable<Deal> IncludeChatAndParticipants(this IQueryable<Deal> deals) =>
            deals
                .Include(e => e.Chat)
                .ThenInclude(e => e.Messages)
                .ThenInclude(e => e.Sender)
                .Include(e => e.Chat)
                .ThenInclude(e => e.Participants);
    }
}
