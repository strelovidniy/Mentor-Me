using Assignment = Mentor.Me.Data.Entities.Assignment;
using AssignmentStatus = Mentor.Me.Data.Enums.AssignmentStatus;

namespace Mentor.Me.Domain.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<Assignment> GetTaskByIdAsync(Guid taskId);
        public Task<Assignment> AddTaskAsync(Assignment task);
        public Task<Assignment> UpdateTaskAsync(Assignment task);
        public Task<Assignment> UpdateTaskStatusAsync(Guid taskId, AssignmentStatus taskStatus);
    }
}
