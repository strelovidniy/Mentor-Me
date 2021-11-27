using System;
using System.Collections.Generic;

namespace Mentor.Me.Data.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public IEnumerable<Proposition> Propositions { get; set; }
        public IEnumerable<ApplyRequest> ApplyRequests { get; set; }
        public IEnumerable<Deal> Deals { get; set; }
        public IEnumerable<Assignment> Tasks { get; set; }
    }
}