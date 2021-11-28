using Mentor.Me.Data.Entities;

namespace Mentor.Me.Domain.Services.Interfaces
{
    public interface IApplyRequestService
    {
        Task<ApplyRequest> AddApplyRequestAsync(ApplyRequest applyRequest);
        Task<ApplyRequest> GetApplyRequestById(Guid goalId);
        Task<IEnumerable<ApplyRequest>> GetApplyRequestForPropositionAsync(Guid propositionId);
    }
}