using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Domain.Services.Interfaces;
using Task = Mentor.Me.Data.Entities.Task;
using TaskStatus = Mentor.Me.Data.Enums.TaskStatus;

namespace Mentor.Me.Domain.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<Task> _taskRepository;

        public TaskService(IRepository<Task> taskRepository) =>
            _taskRepository = taskRepository;

        public async Task<Task> GetTaskByIdAsync(Guid goalId) =>
            await _taskRepository.GetByIdAsync(goalId);

        public async Task<Task> AddTaskAsync(Task task)
        {
            var addedTask = await _taskRepository.AddAsync(task);

            await _taskRepository.SaveChangesAsync();

            return addedTask;
        }

        public async Task<Task> UpdateTaskAsync(Task task)
        {
            var updatingTask = await GetTaskByIdAsync(task.Id);

            if (updatingTask == null) return null;

            updatingTask.Name = task.Name;
            updatingTask.Description = task.Description;
            updatingTask.Deadline = task.Deadline;
            updatingTask.OwnerId = task.OwnerId;
            updatingTask.SkillId = task.SkillId;
            updatingTask.Status = task.Status;

            // do we need updating task Members ? If no, remove that line

            await _taskRepository.SaveChangesAsync();

            return updatingTask;
        }

        public async Task<Task> UpdateTaskStatusAsync(Guid taskId, TaskStatus taskStatus)
        {
            var updatingTask = await GetTaskByIdAsync(taskId);

            if (updatingTask == null) return null;

            updatingTask.Status = taskStatus;

            await _taskRepository.SaveChangesAsync();

            return updatingTask;
        }
    }
}
