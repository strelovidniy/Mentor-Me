using Mentor.Me.Data.Entities;
using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mentor.Me.Domain.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly IRepository<Skill> _skillRepository;

        public SkillService(IRepository<Skill> skillRepository) =>
            _skillRepository = skillRepository;

        public async Task<IEnumerable<Skill>> GetSkillsByPropositionIdAsync(Guid propositionId) =>
            await _skillRepository.Query().Where(x => x.PropositionId == propositionId).ToListAsync();

        public async void AddSkillsAsync(IEnumerable<Skill> skills)
        {
            foreach (var item in skills)
            {
                await _skillRepository.AddAsync(item);
            }

            await _skillRepository.SaveChangesAsync();
        }
    }
}
