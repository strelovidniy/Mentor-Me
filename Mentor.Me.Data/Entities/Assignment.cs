using System;
using System.Collections.Generic;
namespace Mentor.Me.Data.Entities
{
    public class Assignment : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Guid OwnerId { get; set; }
        public Guid SkillId { get; set; }
        public AssignmentStatus Status { get; set; }
        public IEnumerable<User> Members { get; set; }
    }
}