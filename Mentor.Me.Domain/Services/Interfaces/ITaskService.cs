namespace Mentor.Me.Domain.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<Data.Entities.Task> GetTaskByIdAsync(Guid taskId);
        public Task<Data.Entities.Task> AddTaskAsync(Data.Entities.Task task);
        public Task<Data.Entities.Task> UpdateTaskAsync(Data.Entities.Task task);
        public Task<Data.Entities.Task> UpdateTaskStatusAsync(Guid taskId, Data.Enums.TaskStatus taskStatus);
    }
}
