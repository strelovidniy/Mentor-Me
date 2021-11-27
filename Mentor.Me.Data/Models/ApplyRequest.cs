using Mentor.Me.Data.Interfaces;

namespace Mentor.Me.Data.Models
{
    public class ApplyRequest : IEntity
    {
        public Guid Id { get; set; }
        public Guid PropositionId { get; set; }
        public Guid OwnerId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}