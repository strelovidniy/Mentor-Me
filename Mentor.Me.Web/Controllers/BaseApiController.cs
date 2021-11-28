using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {
        internal string GetHostUrl() => $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";

        internal string GetUserEmail() =>
            HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value!;
    }
}