using System.Linq;
using Mentor.Me.Data.Entities;
using Mentor.Me.Data.Enums;
using Mentor.Me.Data.Infrastructure;
using Mentor.Me.Domain.Extensions.ServicesExtensions;
using Mentor.Me.Domain.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Mentor.Me.Domain.Services.Implementations
{
    public class ChatService : IChatService
    {
        private readonly IRepository<Chat> _chatRepository;
        private readonly IUserService _userService;

        public ChatService(
            IRepository<Chat> chatRepository,
            IUserService userService
        )
        {
            _chatRepository = chatRepository;
            _userService = userService;
        }

        public Task<Chat> GetChatByIdAsync(Guid chatId) =>
            _chatRepository
                .Query()
                .IncludeMessages()
                .IncludeParticipants()
                .FirstOrDefaultAsync(chat => chat.Id == chatId)!;
        
        public async Task<IEnumerable<Chat>> GetUnreadChatsByUserIdAsync(Guid userId) =>
            await _chatRepository
                .Query()
                .Where(chat => chat.HasUnreadMessages)
                .ToListAsync();

        public async Task<IEnumerable<Chat>> GetReadChatsByUserIdAsync(Guid userId) =>
            await _chatRepository
                .Query()
                .Where(chat => !chat.HasUnreadMessages)
                .ToListAsync();

        public async Task<Message> AddMessageToChat(Message message)
        {
            var chat = await _chatRepository
                .Query()
                .IncludeParticipants()
                .IncludeMessages()
                .FirstOrDefaultAsync(chat => chat.Id == message.ChatId);

            var messages = chat.Messages.ToList();

            messages.Add(message);

            chat.Messages = messages;

            return message;
        }
        
        public async Task<Message> AddMessageToChatAsync(Message message)
        {
            var chat = await GetChatByIdAsync(message.ChatId);

            if (chat is null) return null;

            var messages = chat.Messages.ToList();

            messages.Add(message);

            chat.Messages = messages;

            await _chatRepository.SaveChangesAsync();

            return message;
        }
    }
}