using Task = Mentor.Me.Data.Entities.Task;
using TaskStatus = Mentor.Me.Data.Enums.TaskStatus;

namespace Mentor.Me.Domain.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<Task> GetTaskByIdAsync(Guid taskId);
        public Task<Task> AddTaskAsync(Task task);
        public Task<Task> UpdateTaskAsync(Task task);
        public Task<Task> UpdateTaskStatusAsync(Guid taskId, TaskStatus taskStatus);
    }
}
