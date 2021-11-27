using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddTaskAsync(Data.Entities.Task task) =>
            Ok(await _taskService.AddTaskAsync(task));

        [HttpPut]
        public async Task<IActionResult> UpdateTaskAsync(Data.Entities.Task task) =>
            Ok(await _taskService.UpdateTaskAsync(task));

        [HttpPut("{taskId:guid}/{taskStatus}")]
        public async Task<IActionResult> UpdateTaskStatusAsync(Guid taskId, Data.Enums.TaskStatus taskStatus) =>
            Ok(await _taskService.UpdateTaskStatusAsync(taskId, taskStatus));
    }
}
