using Mentor.Me.Data.Entities;
using Mentor.Me.Data.Enums;
using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Domain.Extensions.ServicesExtensions;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mentor.Me.Domain.Services.Implementations
{
    public class PropositionService : IPropositionService
    {
        private readonly IRepository<Proposition> _propositionRepository;
        private readonly ISkillService _skillService;

        public PropositionService(
            IRepository<Proposition> propositionRepository,
            ISkillService skillService)
        {
            _propositionRepository = propositionRepository;
            _skillService = skillService;
        }

        public async Task<IEnumerable<Proposition>> GetOffersPropositionsAsync(string? filter) =>
            await _propositionRepository
                .Query()
                .Where(p => p.Type == PropositionType.Offer && (filter == null || p.Name.Contains(filter) || p.Description.Contains(filter)))
                .IncludeMembersAndSkills()
                .ToListAsync();

        public async Task<IEnumerable<Proposition>> GetRequestsPropositionsAsync(string? filter) =>
            await _propositionRepository
                .Query()
                .Where(p => p.Type == PropositionType.Request && (filter == null || p.Name.Contains(filter) || p.Description.Contains(filter)))
                .IncludeMembersAndSkills()
                .ToListAsync();

        public async Task<Proposition> GetPropositionByIdAsync(Guid propositionId) =>
            await _propositionRepository.Query().FirstOrDefaultAsync(proposition => proposition.Id == propositionId);

        public async Task<Proposition> AddPropositionAsync(Proposition proposition)
        {
            var addedProposition = await _propositionRepository.UpdateAsync(proposition);

            await _propositionRepository.SaveChangesAsync();

            return addedProposition;
        }
    }
}
