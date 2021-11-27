using System;
using System.Collections.Generic;
using Mentor.Me.Data.Interfaces;
using Mentor.Me.Data.Models.Enums;

namespace Mentor.Me.Data.Models
{
    public class Task : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Guid OwnerId { get; set; }
        public Guid SkillId { get; set; }
        public TaskStatus Status { get; set; }
        public IEnumerable<User> Members { get; set; }
    }
}