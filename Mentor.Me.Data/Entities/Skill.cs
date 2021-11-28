namespace Mentor.Me.Data.Entities
{
    public class Skill : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PropositionId { get; set; }
        public IEnumerable<Assignment> Tasks { get; set; }
    }
}