using Mentor.Me.Data.Entities;

namespace Mentor.Me.Domain.Services.Interfaces
{
    public interface IDealService
    {
        public Task<Deal> CreateDeal(Guid applyRequestId);
    }
}