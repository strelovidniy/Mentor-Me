using Mentor.Me.Data.Entities;
using Mentor.Me.Data.Enums;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [Route("api/v1/tasks")]
    public class TaskController : BaseApiController
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService) =>
            _taskService = taskService;

        [HttpGet("{taskId:guid}")]
        public async Task<IActionResult> GetTaskByIdAsync(Guid taskId) =>
            Ok(await _taskService.GetTaskByIdAsync(taskId));

        [HttpPost]
        public async Task<IActionResult> AddTaskAsync(Assignment task) =>
            Ok(await _taskService.AddTaskAsync(task));

        [HttpPut]
        public async Task<IActionResult> UpdateTaskAsync(Assignment task) =>
            Ok(await _taskService.UpdateTaskAsync(task));

        [HttpPut("{taskId:guid}/{taskStatus}")]
        public async Task<IActionResult> UpdateTaskStatusAsync(Guid taskId, AssignmentStatus taskStatus) =>
            Ok(await _taskService.UpdateTaskStatusAsync(taskId, taskStatus));
    }
}
