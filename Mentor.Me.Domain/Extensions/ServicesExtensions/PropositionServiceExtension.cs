using Mentor.Me.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mentor.Me.Domain.Extensions.ServicesExtensions
{
    public static class PropositionServiceExtension
    {
        public static IQueryable<Proposition> IncludeMembersAndSkills(this IQueryable<Proposition> propositions) =>
            propositions
                .Include(e => e.Members)
                .Include(e => e.Skills)
                .ThenInclude(e => e.Tasks)
                .ThenInclude(e => e.Members);
    }
}
