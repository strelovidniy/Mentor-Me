using System.Linq;
using Mentor.Me.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mentor.Me.Domain.Extensions.ServicesExtensions
{
    public static class UserServiceExtension
    {
        public static IQueryable<User> IncludeAll(this IQueryable<User> users) =>
            users
                .Include(e => e.Deals)
                .ThenInclude(e => e.Chat)
                .ThenInclude(e => e.Messages)
                .ThenInclude(e => e.Sender)
                .Include(e => e.Deals)
                .ThenInclude(e => e.Members)
                .Include(e => e.ApplyRequests)
                .Include(e => e.Tasks)
                .ThenInclude(e => e.Members);
    }
}
