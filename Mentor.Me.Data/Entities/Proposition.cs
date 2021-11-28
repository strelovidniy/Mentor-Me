using Mentor.Me.Data.Enums;

namespace Mentor.Me.Data.Entities
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
        public IEnumerable<Skill> Skills { get; set; }
    }
}