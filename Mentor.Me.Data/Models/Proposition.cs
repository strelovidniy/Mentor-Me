using Mentor.Me.Data.Interfaces;
using Mentor.Me.Data.Models.Enums;

namespace Mentor.Me.Data.Models
{
    public class Proposition : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PropositionType Type { get; set; }
        public decimal StartPrice { get; set; }
        public bool Active { get; set; }
        public Guid OwnerId { get; set; }
        public IEnumerable<User> Members { get; set; }
    }
}