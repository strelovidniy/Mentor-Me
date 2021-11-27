using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Me.Web.Controllers
{
    [Route("api/v1/chats")]
    public class ChatController : BaseApiController
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService) =>
            _chatService = chatService;

        [HttpGet("unread/{userId:guid}")]
        public async Task<IActionResult> GetUnreadChatsAsync(Guid userId) => 
            Ok(await _chatService.GetUnreadChatsByUserIdAsync(userId));

        [HttpGet("read/{userId:guid}")]
        public async Task<IActionResult> GetReadChatsAsync(Guid userId) => 
            Ok(await _chatService.GetReadChatsByUserIdAsync(userId));

        [HttpGet("{chatId:guid}")]
        public async Task<IActionResult> SendMessageAsync(Guid chatId) => 
            Ok(await _chatService.GetChatByIdAsync(chatId));
    }
}