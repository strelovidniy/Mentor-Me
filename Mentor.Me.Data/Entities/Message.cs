using System;

namespace Mentor.Me.Data.Entities
{
    public class Message : IEntity
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid SenderId { get; set; }
        public User Sender { get; set; }
        public Guid ChatId { get; set; }
        public DateTime Date { get; set; }
    }
}
