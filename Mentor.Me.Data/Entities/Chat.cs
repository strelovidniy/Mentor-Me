using System;
using System.Collections.Generic;

namespace Mentor.Me.Data.Entities
{
    public class Chat : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> Participants { get; set; }
        public Guid DealId { get; set; }
        public IEnumerable<Message> Messages { get; set; }
        public bool HasUnreadMessages { get; set; }
    }
}
