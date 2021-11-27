using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [ApiController]
    [Authorize]
    public class BaseApiController : ControllerBase
    {
        internal Guid GetUserId(int telegramId) => new();

        internal string GetHostUrl() => $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
    }
}