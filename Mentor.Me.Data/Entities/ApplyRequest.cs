using System;

namespace Mentor.Me.Data.Entities
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