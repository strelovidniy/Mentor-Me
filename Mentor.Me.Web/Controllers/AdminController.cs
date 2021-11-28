using Mentor.Me.Data.Entities;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [ApiController]
    [Route("api/v1/admin")]
    public class AdminController : BaseApiController
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService) => 
            _userService = userService;

        [HttpGet("users")]
        public async Task<IActionResult> GetUsersAsync() =>
            Ok(await _userService.GetAllAsync());

        [HttpPut("users")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] User user) =>
            Ok(await _userService.UpdateUserAsync(user));

        [HttpPost("users")]
        public async Task<IActionResult> AddUserAsync([FromBody] User user) =>
            Ok(await _userService.AddUserAsync(user));

        [HttpDelete("users/{userId:guid}")]
        public async Task<IActionResult> DeleteUserByIdAsync(Guid userId) =>
            Ok(await _userService.RemoveUserByIdAsync(userId));
    }
}
