using Microsoft.Extensions.Logging;

namespace Mentor.Me.Data.Entities
{
    public class Log : IEntity
    {
        public Guid Id { get; set; }
        public LogLevel LogLevel { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string CategoryName { get; set; }
    }
}