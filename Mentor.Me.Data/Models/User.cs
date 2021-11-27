using System;
using System.Collections.Generic;
using Mentor.Me.Data.Interfaces;

namespace Mentor.Me.Data.Models
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public IEnumerable<Proposition> Propositions { get; set; }
    }
}