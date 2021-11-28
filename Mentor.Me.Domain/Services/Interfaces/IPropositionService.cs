using Mentor.Me.Data.Entities;

namespace Mentor.Me.Domain.Services.Interfaces
{
    public interface IPropositionService
    {
        public Task<IEnumerable<Proposition>> GetOffersPropositionsAsync(string? filter);
        public Task<IEnumerable<Proposition>> GetRequestsPropositionsAsync(string? filter);
        public Task<Proposition> GetPropositionByIdAsync(Guid propositionId);
        public Task<Proposition> AddPropositionAsync(Proposition proposition);
    }
}
