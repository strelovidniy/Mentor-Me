using System;
using System.Collections.Generic;

namespace Mentor.Me.Domain.Models
{
    public class CreateMeetingModel
    {
        public IEnumerable<string> Emails { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
    }
}