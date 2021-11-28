using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Mentor.Me.Domain.Services.Interfaces;
using Mentor.Me.Web.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Self.Improvement.Web.Controllers
{
    [Route("api/v1/account"), AllowAnonymous]
    public class AccountController : BaseApiController
    {
        private readonly string _userEmail;
        private readonly IUserService _userService;
        
        public AccountController(
            IHttpContextAccessor httpContextAccessor,
            IUserService userService
        )
        {
            _userService = userService;
            _userEmail = httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
        }

        [Route("current-user")]
        public async Task<IActionResult> GetCurrentUserAsync(CancellationToken ct) =>
            Ok(await _userService.GetUserByEmailIfExistAsync(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value!, ct));

        [Route("authenticate")]
        public IActionResult GoogleLogin() =>
            Challenge(new AuthenticationProperties { RedirectUri = Url.Action("RedirectUrl") }, GoogleDefaults.AuthenticationScheme);

        [Route("redirect-url")]
        public async Task<IActionResult> RedirectUrl(CancellationToken ct)
        {
            await _userService.CreateNewUserIfNotExistAsync(User.FindFirst(ClaimTypes.Email)?.Value,
                User.FindFirst(ClaimTypes.Name)?.Value, ct);
            return RedirectPermanent($"{GetHostUrl()}");
        }
    }
}