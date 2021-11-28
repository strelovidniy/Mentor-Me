using Mentor.Me.Data.Entities;
using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mentor.Me.Domain.Services.Implementations
{
    public class ApplyRequestService : IApplyRequestService
    {
        private readonly IRepository<ApplyRequest> _applyRepository;
        private readonly IRepository<Proposition> _propositionRepository;

        public ApplyRequestService(
            IRepository<ApplyRequest> repository,
            IRepository<Proposition> propositionRepository
        )
        {
            _propositionRepository = propositionRepository;
            _applyRepository = repository;
        }

        public async Task<ApplyRequest> GetApplyRequestById(Guid goalId) => 
            await _applyRepository.GetByIdAsync(goalId);

        public async Task<ApplyRequest> AddApplyRequestAsync(ApplyRequest applyRequest)
        {
            var addedApply = await _applyRepository.AddAsync(applyRequest);

            await _applyRepository.SaveChangesAsync();

            return addedApply;
        }

        public async Task<IEnumerable<ApplyRequest>> GetApplyRequestForPropositionAsync(Guid propositionId) => 
            await _applyRepository.Query().Where(x => x.PropositionId == propositionId).ToListAsync();

        public async Task<IEnumerable<IEnumerable<ApplyRequest>>> GetApplyRequestsByUserIdAsync(Guid userId)
        {
            var res = new List<IEnumerable<ApplyRequest>>();


            foreach (var awaitableElement in _propositionRepository
                         .Query()
                         .Where(e => e.OwnerId == userId)
                         .ToList().Select(e => GetApplyRequestForPropositionAsync(e.Id)))
            {
                res.Add(await awaitableElement);
            }

            return res;
        }
    }
}