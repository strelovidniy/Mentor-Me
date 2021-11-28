using System;
using System.Threading.Tasks;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [Route("api/v1/chats")]
    public class ChatController : BaseApiController
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService) =>
            _chatService = chatService;

        [HttpGet("{chatId:guid}"), AllowAnonymous]
        public async Task<IActionResult> SendMessageAsync(Guid chatId) => 
            Ok(await _chatService.GetChatByIdAsync(chatId));
    }
}