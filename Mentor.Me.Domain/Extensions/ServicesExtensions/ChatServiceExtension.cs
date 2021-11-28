using Mentor.Me.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mentor.Me.Domain.Extensions.ServicesExtensions
{
    public static class ChatServiceExtension
    {
        public static IQueryable<Chat> IncludeMessages(this IQueryable<Chat> chats) =>
            chats
                .Include(chat => chat.Messages);

        public static IQueryable<Chat> IncludeParticipants(this IQueryable<Chat> chats) =>
            chats
                .Include(chat => chat.Participants);
    }
}
