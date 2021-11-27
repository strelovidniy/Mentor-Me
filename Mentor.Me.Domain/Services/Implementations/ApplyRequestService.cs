using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mentor.Me.Data.Entities;
using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mentor.Me.Domain.Services.Implementations
{
    public class ApplyRequestService : IApplyRequestService
    {
        private readonly IRepository<ApplyRequest> _applyRepository;
        
        public ApplyRequestService(IRepository<ApplyRequest> repository)
        {
            _applyRepository = repository;
        }
        
        public async Task<ApplyRequest> GetApplyRequestById(Guid goalId)
        {
            return await _applyRepository.GetByIdAsync(goalId);
        }
        
        public async Task<ApplyRequest> AddApplyRequestAsync(ApplyRequest applyRequest)
        {
            var addedApply = await _applyRepository.AddAsync(applyRequest);
            await _applyRepository.SaveChangesAsync();
            return addedApply;
        }
        
        public async Task<IEnumerable<ApplyRequest>> GetApplyRequestForPropositionAsync(Guid propositionId)
        {
            return await _applyRepository.Query().Where(x=> x.PropositionId == propositionId).ToListAsync();
        }
    }
}