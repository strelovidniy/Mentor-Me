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
    [AllowAnonymous, Route("api/users")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [Authorize]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsersAsync() =>
            Ok(await _userService.GetAllAsync());
        
        [Authorize]
        [HttpPut("users")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] User user) =>
            Ok(await _userService.UpdateUserAsync(user));

        [Authorize]
        [HttpPost("users")]
        public async Task<IActionResult> AddUserAsync([FromBody] User user) =>
            Ok(await _userService.AddUserAsync(user));

        [Authorize]
        [HttpDelete("users/{userId:guid}")]
        public async Task<IActionResult> DeleteUserByIdAsync(Guid userId) =>
            Ok(await _userService.RemoveUserByIdAsync(userId));
        
        [Route("authenticate")]
        public IActionResult GoogleLogin()
        {
            var authProperties = new AuthenticationProperties { RedirectUri = Url.Action("RedirectUrl") };
            return Challenge(authProperties, GoogleDefaults.AuthenticationScheme);
        }
        
        [Route("redirectUrl")]
        public async Task<IActionResult> RedirectUrl(CancellationToken ct)
        {
            await _userService.CreateNewUserIfNotExistAsync(User.FindFirst(ClaimTypes.Email)?.Value,
                User.FindFirst(ClaimTypes.Name)?.Value, ct);
            return RedirectPermanent($"{GetHostUrl()}");
        }
    }
}