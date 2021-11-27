using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mentor.Me.Data.Entities;

namespace Mentor.Me.Domain.Services.Interfaces
{
    public interface ISkillService
    {
        public Task<IEnumerable<Skill>> GetSkillsByPropositionIdAsync(Guid propositionId);
        public void AddSkillsAsync(IEnumerable<Skill> skills);
    }
}
