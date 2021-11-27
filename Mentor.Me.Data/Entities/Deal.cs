using System;
using System.Collections.Generic;

namespace Mentor.Me.Data.Entities
{
    public class Deal : IEntity
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid PropositionId { get; set; }
        public IEnumerable<User> Members { get; set; }
    }
}