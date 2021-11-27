using Mentor.Me.Data.Interfaces;

namespace Mentor.Me.Data.Models
{
    public class Skill : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PropositionId { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}