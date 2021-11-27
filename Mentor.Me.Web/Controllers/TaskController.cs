using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Task = Mentor.Me.Data.Entities.Task;
using TaskStatus = Mentor.Me.Data.Enums.TaskStatus;

namespace Mentor.Me.Web.Controllers
{
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService) =>
            _taskService = taskService;

        [HttpGet("{taskId:guid}")]
        public async Task<IActionResult> GetTaskByIdAsync(Guid taskId) =>
            Ok(await _taskService.GetTaskByIdAsync(taskId));

        [HttpPost]
        public async Task<IActionResult> AddTaskAsync(Task task) =>
            Ok(await _taskService.AddTaskAsync(task));

        [HttpPut]
        public async Task<IActionResult> UpdateTaskAsync(Task task) =>
            Ok(await _taskService.UpdateTaskAsync(task));

        [HttpPut("{taskId:guid}/{taskStatus}")]
        public async Task<IActionResult> UpdateTaskStatusAsync(Guid taskId, TaskStatus taskStatus) =>
            Ok(await _taskService.UpdateTaskStatusAsync(taskId, taskStatus));
    }
}
