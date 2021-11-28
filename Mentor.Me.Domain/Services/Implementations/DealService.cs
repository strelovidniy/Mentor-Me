using Mentor.Me.Data.Entities;
using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Domain.Services.Interfaces;

namespace Mentor.Me.Domain.Services.Implementations
{
    public class DealService : IDealService
    {
        private readonly IRepository<ApplyRequest> _applyRequestRepository;
        private readonly IRepository<Deal> _dealRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Proposition> _propositionRepository;

        public DealService(IRepository<ApplyRequest> applyRequestRepository, IRepository<Deal> dealRepository, IRepository<User> userRepository, IRepository<Proposition> propositionRepository)
        {
            _applyRequestRepository = applyRequestRepository;
            _dealRepository = dealRepository;
            _userRepository = userRepository;
            _propositionRepository = propositionRepository;
        }

        public async Task<Deal> CreateDeal(Guid applyRequestId)
        {
            var applyRequest = await _applyRequestRepository.GetByIdAsync(applyRequestId);
            var proposition = await _propositionRepository.GetByIdAsync(applyRequest.PropositionId);

            var user = await _userRepository.GetByIdAsync(applyRequest.OwnerId);
            var owner = await _userRepository.GetByIdAsync(proposition.OwnerId);
            
            var deal = _dealRepository.Query().FirstOrDefault(x => x.PropositionId == applyRequest.PropositionId);
            if (deal == null)
            {
                deal = await _dealRepository.AddAsync(new Deal()
                {
                    OwnerId = proposition.OwnerId,
                    PropositionId = proposition.Id,
                    Members = new[] {user, owner},
                    Chat = new Chat
                    {
                        Participants = new[] {user, owner},
                        Name = $"{proposition.Name} chat",
                        HasUnreadMessages = false,
                        Messages = new List<Message>(),
                    },
                });
            }
            else
            {
                //Todo: add member to chat
                deal.Members.ToList().Add(user);
            }

            await _dealRepository.SaveChangesAsync();

            return deal;
        }
    }
}