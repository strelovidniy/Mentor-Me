using Microsoft.AspNetCore.SignalR;
using Mentor.Me.Data.Entities;
using Mentor.Me.Domain.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Mentor.Me.Domain.Hubs
{
    public class SignalRHub : Hub
    {
        private IChatService _chatService;

        public SignalRHub(IChatService chatService) => _chatService = chatService;

        public async Task EnterToGroup(string groupName) =>
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        public async Task LeaveTheGroup(string groupName) =>
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        public async Task SendMessageToGroup(Message message)
        {
            var msg = await _chatService.AddMessageToChatAsync(message);

            await Clients
                .Group(message.ChatId.ToString())
                .SendAsync("RecieveMessage", msg);
        }
    }
}