using Mentor.Me.Data.Entities;

namespace Mentor.Me.Domain.Services.Interfaces
{
    public interface IDealService
    {
        public Task<Deal> CreateDeal(Guid applyRequestId);
        public Task<Deal> GetDealByIdAsync(Guid dealId);
        public Task<IEnumerable<Deal>> GetDealsByUserIdAsync(Guid userId);
    }
}