using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Mentor.Me.Data.Entities;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{   
    [AllowAnonymous, Route("api/v1/users")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => 
            _userService = userService;

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync() =>
            Ok(await _userService.GetAllAsync());
        
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] User user) =>
            Ok(await _userService.UpdateUserAsync(user));

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] User user) =>
            Ok(await _userService.AddUserAsync(user));

        [Authorize]
        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> DeleteUserByIdAsync(Guid userId) =>
            Ok(await _userService.RemoveUserByIdAsync(userId));
    }
}