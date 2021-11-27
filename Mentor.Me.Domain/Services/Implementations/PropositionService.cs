using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mentor.Me.Data.Entities;
using Mentor.Me.Data.Infrastructure;
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

        public async Task<IEnumerable<Proposition>> GetAllPropositionsAsync() =>
            await _propositionRepository.Query().ToListAsync();

        public async Task<Proposition> GetPropositionByIdAsync(Guid propositionId) =>
            await _propositionRepository.Query().FirstOrDefaultAsync(proposition => proposition.Id == propositionId);

        public async Task<Proposition> AddPropositionAsync(Proposition proposition)
        {
            _skillService.AddSkillsAsync(proposition.Skills);

            var addedProposition = await _propositionRepository.AddAsync(proposition);

            await _propositionRepository.SaveChangesAsync();

            return addedProposition;
        }
    }
}
