using System;
using System.Threading.Tasks;
using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Domain.Services.Interfaces;
using Assignment = Mentor.Me.Data.Entities.Assignment;
using AssignmentStatus = Mentor.Me.Data.Enums.AssignmentStatus;

namespace Mentor.Me.Domain.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<Assignment> _taskRepository;

        public TaskService(IRepository<Assignment> taskRepository) =>
            _taskRepository = taskRepository;

        public async Task<Assignment> GetTaskByIdAsync(Guid goalId) =>
            await _taskRepository.GetByIdAsync(goalId);

        public async Task<Assignment> AddTaskAsync(Assignment task)
        {
            var addedTask = await _taskRepository.AddAsync(task);

            await _taskRepository.SaveChangesAsync();

            return addedTask;
        }

        public async Task<Assignment> UpdateTaskAsync(Assignment task)
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

        public async Task<Assignment> UpdateTaskStatusAsync(Guid taskId, AssignmentStatus taskStatus)
        {
            var updatingTask = await GetTaskByIdAsync(taskId);

            if (updatingTask == null) return null;

            updatingTask.Status = taskStatus;

            await _taskRepository.SaveChangesAsync();

            return updatingTask;
        }
    }
}
